using Bogus;
using Dominio.Entidades;
using Dominio.Models;

namespace Fixtures
{
    public class ProdutoFixture
    {
        public static IList<Produto> Produtos(int quantidade = 10)
        {
            var faker = new Faker<Produto>("pt_BR");
            faker.RuleFor(m => m.Id, m => m.IndexGlobal);
            faker.RuleFor(m => m.Codigo, m => m.Random.String());
            faker.RuleFor(m => m.Nome, m => m.Lorem.Word());
            faker.RuleFor(m => m.Descricao, m => m.Lorem.Word());
            faker.RuleFor(m => m.Preco, m => m.Random.Decimal(1));
            faker.RuleFor(m => m.Ativo, true);
            return faker.Generate(quantidade);
        }

        public static List<ProdutoUpsertRequest> ProdutosUpsert(int quantidade = 10)
        {
            var faker = new Faker<ProdutoUpsertRequest>("pt_BR");
            faker.RuleFor(m => m.Codigo, m => m.Random.String());
            faker.RuleFor(m => m.Nome, m => m.Lorem.Word());
            faker.RuleFor(m => m.Descricao, m => m.Lorem.Word());
            faker.RuleFor(m => m.Preco, m => m.Random.Decimal(1));
            faker.RuleFor(m => m.Ativo, true);
            return faker.Generate(quantidade);
        }
    }
}