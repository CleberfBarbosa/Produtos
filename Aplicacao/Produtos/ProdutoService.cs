using Aplicacao.Interfaces;
using AutoMapper;
using Dominio.Entidades;
using Dominio.Interfaces.Repositorio;
using Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Produtos
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        private readonly IMapper _mapper;

        public ProdutoService(IProdutoRepositorio produtoRepositorio,
            IMapper mapper)
        {
            _produtoRepositorio = produtoRepositorio;
            _mapper = mapper;
        }

        public List<ProdutoPesquisaResponse> Pesquisar(ProdutoPesquisaRequest produtoPesquisaRequest)
        {
            var produtosEncontrados = _produtoRepositorio.Pesquisar(produtoPesquisaRequest)?.ToList() ?? new List<Produto>();
            return _mapper.Map<List<ProdutoPesquisaResponse>>(produtosEncontrados);
        }

        public void Remover(ProdutoRemoverRequest produtoRemoverRequest)
        {
            var produtosExistentes = _produtoRepositorio.ProdutosPorCodigo(produtoRemoverRequest.CodigosProdutos)?.ToList() ?? new List<Produto>();
            produtosExistentes.ForEach(prod => prod.Inativar());
            _produtoRepositorio.Atualizar(produtosExistentes);
        }

        public void Upsert(List<ProdutoUpsertRequest> produtosUpsert)
        {
            var codigosProdutos = produtosUpsert.Select(prod => prod.Codigo).ToList();
            var produtosExistentes = _produtoRepositorio.ProdutosPorCodigo(codigosProdutos);

            var produtosAdicionar = new List<Produto>();
            var produtosAtualizar = new List<Produto>();
            foreach (var produtoUpsert in produtosUpsert)
            {
                var produtoExistente = produtosExistentes.FirstOrDefault(prod => prod.Codigo == produtoUpsert.Codigo);
                if (produtoExistente != null)
                {
                    produtoExistente.Atualizar(produtoUpsert.Nome, produtoUpsert.Descricao, produtoUpsert.Preco, produtoUpsert.Ativo);
                    produtosAtualizar.Add(produtoExistente);
                }
                else
                {
                    var produtoInserir = _mapper.Map<Produto>(produtoUpsert);
                    produtosAdicionar.Add(produtoInserir);
                }
            }

            _produtoRepositorio.Atualizar(produtosAtualizar);
            _produtoRepositorio.Inserir(produtosAdicionar);
        }
    }
}
