using Dominio.Entidades;
using Infra.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;

namespace Fixtures
{
    public class DbContextMock
    {
        public static DbContext Context()
        {
            var mockDbContext = new Mock<ProdutoContext>();
            mockDbContext.Setup(m => m.Set<Produto>())
                .ReturnsDbSet(ProdutoFixture.Produtos());

            return mockDbContext.Object;
        }
    }
}
