using Aplicacao.Interfaces;
using Dominio.Models;
using Microsoft.AspNetCore.Mvc;

namespace Produtos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpPut("adicionar")]
        public IActionResult Adicionar(List<ProdutoUpsertRequest> produtosInserir)
        {
            _produtoService.Upsert(produtosInserir);
            return Ok();
        }

        [HttpPost("atualizar")]
        public IActionResult Atualizar(List<ProdutoUpsertRequest> produtosAtualizar)
        {
            _produtoService.Upsert(produtosAtualizar);
            return Ok();
        }

        [HttpDelete("remover")]
        public IActionResult Remover(ProdutoRemoverRequest produtosRemoverRequest)
        {
            _produtoService.Remover(produtosRemoverRequest);
            return Ok();
        }

        [HttpPost("pesquisar")]
        public ActionResult<List<ProdutoPesquisaResponse>> Adicionar(ProdutoPesquisaRequest produtoPesquisaRequest)
        {
            var resultado = _produtoService.Pesquisar(produtoPesquisaRequest);
            return Ok(resultado);
        }
    }
}
