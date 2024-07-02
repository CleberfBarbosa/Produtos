namespace Dominio.Models
{
    public class ProdutoPesquisaResponse
    {
        public string Codigo { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public decimal Preco { get; private set; }
        public bool Ativo { get; private set; }

        public ProdutoPesquisaResponse(string codigo, string nome, string descricao, decimal preco, bool ativo)
        {
            Codigo = codigo;
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            Ativo = ativo;
        }
    }
}
