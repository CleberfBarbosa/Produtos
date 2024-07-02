using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntityFramework.Mapeamentos
{
    public class ProdutoMapeamento : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.Property(x => x.Codigo).IsRequired();
            builder.Property(x => x.Nome).IsRequired();
            builder.Property(x => x.Descricao).IsRequired();
            builder.Property(x => x.Preco).IsRequired().HasColumnType(ProdutoContext.PRECISAO_DECIMAL);
            builder.Property(x => x.Ativo).IsRequired().HasDefaultValue(true);

            builder.HasIndex(x => x.Codigo).IsUnique();
        }
    }
}
