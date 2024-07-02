using Dominio.Exceptions;
using Dominio.Interfaces;

namespace Dominio.Entidades
{
    public class Produto : IEntidade
    {
        public long Id { get; private set; }
        public string Codigo { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public decimal Preco { get; private set; }
        public bool Ativo { get; private set; }

        public Produto() { }

        public Produto(string codigo, string nome, string descricao, decimal preco, bool ativo)
        {
            DominioException.ThrowWhen(string.IsNullOrEmpty(codigo), "Código inválido!");
            DominioException.ThrowWhen(string.IsNullOrEmpty(nome), "Nome inválido!");
            DominioException.ThrowWhen(string.IsNullOrEmpty(descricao), "Descrição inválida!");
            DominioException.ThrowWhen(preco < 0.01m, "Preço inválido!");

            Codigo = codigo;
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            Ativo = ativo;
        }

        public void Atualizar(string nome, string descricao, decimal preco, bool ativo)
        {
            DominioException.ThrowWhen(string.IsNullOrEmpty(nome), "Nome inválido!");
            DominioException.ThrowWhen(string.IsNullOrEmpty(descricao), "Descrição inválida!");
            DominioException.ThrowWhen(preco < 0.01m, "Preço inválido!");

            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            Ativo = ativo;
        }

        public void Inativar() => Ativo = false;
        public void Ativar() => Ativo = true;
    }
}
