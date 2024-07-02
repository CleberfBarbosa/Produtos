using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infra.EntityFramework
{
    public class ProdutoContext : DbContext
    {
        public const string PRECISAO_DECIMAL = "decimal(18, 6)";
     
        public ProdutoContext()
        {

        }
        public ProdutoContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
