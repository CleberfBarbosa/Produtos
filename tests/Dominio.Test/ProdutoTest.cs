using Dominio.Entidades;
using Dominio.Exceptions;
using FluentAssertions;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Test
{
    public class ProdutoTest
    {
        [Fact]
        public void Codigo_Invalido()
        {
            // Arrange
            var mensagemEsperada = "Código inválido!";

            // Act

            var action = () => new Produto(null, "nome", "descricao", 1, true);

            // Assert
            action.Should()
                .ThrowExactly<DominioException>()
                .WithMessage(mensagemEsperada);
        }

        [Fact]
        public void Nome_Invalido()
        {
            // Arrange
            var mensagemEsperada = "Nome inválido!";

            // Act

            var action = () => new Produto("1", null, "descricao", 1, true);

            // Assert
            action.Should()
                .ThrowExactly<DominioException>()
                .WithMessage(mensagemEsperada);
        }

        [Fact]
        public void Descricao_Invalida()
        {
            // Arrange
            var mensagemEsperada = "Descrição inválida!";

            // Act

            var action = () => new Produto("1", "Nome", null, 1, true);

            // Assert
            action.Should()
                .ThrowExactly<DominioException>()
                .WithMessage(mensagemEsperada);
        }

        [Fact]
        public void Preco_Invalido()
        {
            // Arrange
            var mensagemEsperada = "Preço inválido!";

            // Act

            var action = () => new Produto("1", "Nome", "Descrição", 0, true);

            // Assert
            action.Should()
                .ThrowExactly<DominioException>()
                .WithMessage(mensagemEsperada);
        }


        [Fact]
        public void Produto_Valido()
        {
            // Arrange
            var objetoEsperado = new
            {
                Codigo = "1",
                Nome = "nome",
                Descricao = "descricao",
                Preco = 1.2m,
                Ativo = true
            };

            // Act

            var produto = new Produto(objetoEsperado.Codigo, objetoEsperado.Nome, objetoEsperado.Descricao, objetoEsperado.Preco, objetoEsperado.Ativo);

            // Assert
            produto.Should().BeEquivalentTo(objetoEsperado);
        }


        [Fact]
        public void Atualizar_Produto()
        {
            // Arrange           

            var produto = Fixtures.ProdutoFixture.Produtos(1).FirstOrDefault();
            var objetoEsperado = new
            {
                Codigo = produto.Codigo,
                Nome = "nome",
                Descricao = "descricao",
                Preco = 1.2m,
                Ativo = true
            };

            // Act
            produto.Atualizar(objetoEsperado.Nome, objetoEsperado.Descricao, objetoEsperado.Preco, objetoEsperado.Ativo);

            // Assert
            produto.Should().BeEquivalentTo(objetoEsperado);
        }
    }
}