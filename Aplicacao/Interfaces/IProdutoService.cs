using Dominio.Models;

namespace Aplicacao.Interfaces
{
    public interface IProdutoService
    {
        void Upsert(List<ProdutoUpsertRequest> produtosUpsert);
        void Remover(ProdutoRemoverRequest produtoRemoverRequest);
        List<ProdutoPesquisaResponse> Pesquisar(ProdutoPesquisaRequest produtoPesquisaRequest);
    }
}
