using Aplicacao.Interfaces;
using Aplicacao.Produtos;
using Dominio.Entidades;
using Dominio.Interfaces.Repositorio;
using Dominio.Models;
using Fixtures;
using Moq;

namespace Aplicacao.Test
{
    public class ProdutoServiceTest
    {
        private readonly Mock<IProdutoRepositorio> _produtoRepositorio;
        private readonly IProdutoService _produtoService;

        public ProdutoServiceTest()
        {
            _produtoRepositorio = new();
            _produtoService = new ProdutoService(_produtoRepositorio.Object, AutoMapperMock.Mapper());
        }

        [Fact]
        public void Update_E_Insert_Produtos()
        {
            // Arrange
            var produtosInsercao = ProdutoFixture.Produtos(5).ToList();
            var produtosAtualizacao = ProdutoFixture.Produtos(5).ToList();
            var produtos = AutoMapperMock.Mapper().Map<List<ProdutoUpsertRequest>>(produtosInsercao.Concat(produtosInsercao).ToList());
            _produtoRepositorio.Setup(m => m.ProdutosPorCodigo(It.IsAny<List<string>>()))
                .Returns(produtosAtualizacao);

            // Act
            _produtoService.Upsert(produtos);

            // Assert
            _produtoRepositorio.Verify(m => m.Inserir(It.Is<List<Produto>>(prod => prod.All(p => produtosInsercao.Any(n => n.Codigo == p.Codigo)))), Times.Once);
            _produtoRepositorio.Verify(m => m.Atualizar(It.Is<List<Produto>>(prod => prod.All(p => produtosAtualizacao.Any(n => n.Codigo == p.Codigo)))), Times.Once);
        }

        [Fact]
        public void Remover_Produtos()
        {
            // Arrange
            var produtosRemover = ProdutoFixture.Produtos(5);
            var produtosRemoverCodigo = new ProdutoRemoverRequest(produtosRemover.Select(prod => prod.Codigo).ToList());
            _produtoRepositorio.Setup(m => m.ProdutosPorCodigo(It.IsAny<List<string>>()))
                .Returns(produtosRemover);

            // Act
            _produtoService.Remover(produtosRemoverCodigo);

            // Assert
            _produtoRepositorio.Verify(m => m.Atualizar(It.Is<List<Produto>>(prod => prod.All(p => !p.Ativo && produtosRemover.Any(n => n.Codigo == p.Codigo)))), Times.Once);
        }
    }
}
