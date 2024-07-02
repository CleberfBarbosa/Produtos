using Dominio.Entidades;
using Dominio.Interfaces.Repositorio;
using Fixtures;
using Infra.EntityFramework;
using Infra.Repositorios;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Test
{
    public class RepositorioProdutoTest
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        private readonly Mock<Repositorio<Produto>> _repositorio;

        public RepositorioProdutoTest()
        {
            _repositorio = new Mock<Repositorio<Produto>>(DbContextMock.Context());
            _repositorio.CallBase = true;
            _produtoRepositorio = new ProdutoRepositorio(_repositorio.Object);
        }

        [Fact]
        public void Inserir_Produto()
        {
            // Arrange
            var produtos = ProdutoFixture.Produtos();

            // Act
            _produtoRepositorio.Inserir(produtos.ToList());

            // Assert
            _repositorio.Verify(m => m.Inserir(It.IsAny<Produto[]>()), Times.Once);
        }

        [Fact]
        public void Atualizar_Produto()
        {
            // Arrange
            var produtos = ProdutoFixture.Produtos();

            // Act
            _produtoRepositorio.Atualizar(produtos.ToList());

            // Assert
            _repositorio.Verify(m => m.Atualizar(It.IsAny<Produto[]>()), Times.Once);
        }

        [Fact]
        public void Pesquisa_Por_Codigo_Lista_Vazia()
        {
            // Arrange
            var codigosBuscar = new List<string>();

            // Act
            var resultado = _produtoRepositorio.ProdutosPorCodigo(codigosBuscar);

            // Assert
            Assert.NotNull(resultado);
            Assert.Empty(resultado);
            _repositorio.Verify(m => m.Filtrar(It.IsAny<Expression<Func<Produto, bool>>>()), Times.Never);
        }

        [Fact]
        public void Pesquisa_Por_Codigo_Retornar_Item()
        {
            // Arrange
            var produto = _repositorio.Object.All().FirstOrDefault();
            var codigosBuscar = new List<string>() { produto.Codigo };

            // Act
            var resultado = _produtoRepositorio.ProdutosPorCodigo(codigosBuscar);

            // Assert
            Assert.NotNull(resultado);
            Assert.NotEmpty(resultado);
            _repositorio.Verify(m => m.Filtrar(It.IsAny<Expression<Func<Produto, bool>>>()), Times.Once);
        }
    }
}
