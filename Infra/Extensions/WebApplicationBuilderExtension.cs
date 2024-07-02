using Dominio.Properties;
using Infra.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;
using Serilog.Exceptions;
using Serilog.Filters;
using System.Reflection;

namespace Infra.Extensions
{
    public static class WebApplicationBuilderExtension
    {
        public static void AddEfContext(this WebApplicationBuilder builder)
        {
            var databaseProperties = builder.GetProperty<DatabaseProperties>(DatabaseProperties.SectionName);
            builder.Services.AddDbContext<ProdutoContext>(option => option.UseSqlServer(databaseProperties.ConnectionString, opt => opt.EnableRetryOnFailure()));
        }

        public static void InitDatabase(this WebApplicationBuilder builder)
        {
            using var dbContext = builder.Services.BuildServiceProvider().GetService<ProdutoContext>();
            dbContext.Database.Migrate();
        }

        public static void ConfigSerilogFile(this WebApplicationBuilder builder)
        {
            var messageTemplate = "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj} {Properties:j}{NewLine}{Exception}";
            var appName = Assembly.GetExecutingAssembly().GetName().Name;

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .Enrich.WithExceptionDetails()
            .Enrich.WithCorrelationId()
                .Filter.ByExcluding(Matching.FromSource("Microsoft.AspNetCore.DataProtection.KeyManagement.XmlKeyManager"))
                .Filter.ByExcluding(Matching.FromSource("Microsoft.Hosting.Lifetime"))
                .Filter.ByExcluding(Matching.FromSource("Microsoft.AspNetCore.StaticFiles"))
                .Filter.ByExcluding(Matching.FromSource("Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker"))
                .Filter.ByExcluding(Matching.FromSource("Microsoft.AspNetCore.Routing.EndpointMiddleware"))
                .Filter.ByExcluding(Matching.FromSource("Microsoft.AspNetCore.Hosting.Diagnostics"))
                .WriteTo.Async(wt => wt.Console(outputTemplate: messageTemplate))
                .WriteTo.Async(wt => wt.File($"logs/log-{appName}-.txt", rollingInterval: RollingInterval.Day, outputTemplate: messageTemplate))
                .CreateLogger();

            builder.Host.UseSerilog(Log.Logger);
        }

        public static T GetProperty<T>(this WebApplicationBuilder builder, string sectionName) where T : class
        {
            var section = builder.Configuration.GetSection(sectionName);
            builder.Services.Configure<T>(section);
            return section.Get<T>();
        }
    }
}
