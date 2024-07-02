using Dominio.Exceptions;

namespace Dominio.Models
{
    public class ProdutoRemoverRequest
    {
        public ProdutoRemoverRequest(List<string> codigosProdutos)
        {
            DominioException.ThrowWhen(codigosProdutos == null || !codigosProdutos.Any(), "Lista de remoção inválida!");
            CodigosProdutos = codigosProdutos;
        }

        public List<string> CodigosProdutos { get; private set; }
    }
}
