using Infra.Extensions;
using Infra.IoC;
using Serilog;

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.ConfigSerilogFile();

    builder.Services.AddControllers();

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    InjetorDependencia.Configure(builder.Services);

    builder.AddEfContext();
    builder.InitDatabase();

    var app = builder.Build();
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    //app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();
    app.Run();

}
catch (Exception ex)
{
    Log.Fatal(ex, "Application has stopped!");
}
finally
{
    Log.Information("Application closure.");
    Log.CloseAndFlush();
}