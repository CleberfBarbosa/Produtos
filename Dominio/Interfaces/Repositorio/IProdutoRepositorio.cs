using Dominio.Entidades;
using Dominio.Models;

namespace Dominio.Interfaces.Repositorio
{
    public interface IProdutoRepositorio
    {
        void Inserir(List<Produto> produtos);
        void Atualizar(List<Produto> produtos);
        IEnumerable<Produto> Pesquisar(ProdutoPesquisaRequest produtoPesquisaRequest);
        IEnumerable<Produto> ProdutosPorCodigo(List<string> codigosProdutos);
    }
}
