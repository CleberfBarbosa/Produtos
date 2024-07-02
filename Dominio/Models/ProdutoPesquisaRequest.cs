using Dominio.Exceptions;
using System.Text.Json.Serialization;

namespace Dominio.Models
{
    public class ProdutoPesquisaRequest
    {
        public string TermoBusca { get; set; }

        [JsonConstructor]
        public ProdutoPesquisaRequest(string termoBusca)
        {
            DominioException.ThrowWhen(string.IsNullOrEmpty(termoBusca), "Não é possível buscar por um termo vázio!");
            TermoBusca = termoBusca;
        }
    }
}
