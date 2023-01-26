using AutoMapper;
using MinhaAPI.Application.Dtos.Produto;
using MinhaAPI.Domain.Entities;

namespace MinhaAPI.Application.Mappers
{
    public class ProdutoMappingProfile : Profile
    {
        public ProdutoMappingProfile()
        {
            Map();
        }

        private void Map()
        {
            CreateMap<Produto, ViewProdutoDto>().ReverseMap();
            CreateMap<Produto, PostProdutoDto>().ReverseMap();
            CreateMap<Produto, PutProdutoDto>().ReverseMap();
        }
    }
}