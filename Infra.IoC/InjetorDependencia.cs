using Aplicacao.Interfaces;
using Aplicacao.Mappers;
using Aplicacao.Produtos;
using Dominio.Interfaces.Repositorio;
using Infra.EntityFramework;
using Infra.Repositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.IoC
{
    public class InjetorDependencia
    {

        public static void Configure(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ProdutoAutoMapper));

            services.AddScoped<DbContext, ProdutoContext>();
            services.AddScoped(typeof(IRepositorio<>), typeof(Repositorio<>));
            services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();

            services.AddScoped<IProdutoService, ProdutoService>();
        }
    }
}
