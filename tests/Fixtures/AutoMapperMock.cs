using Aplicacao.Mappers;
using AutoMapper;

namespace Fixtures
{
    public class AutoMapperMock
    {
        public static IMapper Mapper()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ProdutoAutoMapper());
            });
            return mappingConfig.CreateMapper();
        }
    }
}
