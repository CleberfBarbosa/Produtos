using Dominio.Entidades;
using Dominio.Interfaces.Repositorio;
using Dominio.Models;

namespace Infra.Repositorios
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly IRepositorio<Produto> _repositorio;

        public ProdutoRepositorio(IRepositorio<Produto> repositorio)
        {
            this._repositorio = repositorio;
        }

        public void Atualizar(List<Produto> produtos)
        {
            this._repositorio.Atualizar(produtos.ToArray());
        }

        public void Inserir(List<Produto> produtos)
        {
            this._repositorio.Inserir(produtos.ToArray());
        }

        public IEnumerable<Produto> Pesquisar(ProdutoPesquisaRequest produtoPesquisaRequest)
        {
            var produtos = this._repositorio
                .Filtrar(prod => prod.Nome.ToUpper().Contains(produtoPesquisaRequest.TermoBusca.ToUpper()) ||
                                 prod.Codigo.ToUpper() == produtoPesquisaRequest.TermoBusca.ToUpper())
                ?.ToList() ?? new List<Produto>();
            return produtos;
        }

        public IEnumerable<Produto> ProdutosPorCodigo(List<string> codigosProdutos)
        {
            if(codigosProdutos == null || !codigosProdutos.Any())
                return Enumerable.Empty<Produto>();

            return this._repositorio
                .Filtrar(prod => codigosProdutos.Contains(prod.Codigo))
                ?.ToList() ?? new List<Produto>();
        }
    }
}
