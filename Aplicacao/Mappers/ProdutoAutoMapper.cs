using AutoMapper;
using Dominio.Entidades;
using Dominio.Models;

namespace Aplicacao.Mappers
{
    public class ProdutoAutoMapper : Profile
    {
        public ProdutoAutoMapper()
        {
            CreateMap<Produto, ProdutoUpsertRequest>().ReverseMap();
            CreateMap<Produto, ProdutoPesquisaResponse>().ReverseMap();
        }
    }
}
