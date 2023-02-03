using AutoMapper;
using VitrineAPI.Application.Dtos.SubCategoria;
using VitrineAPI.Domain.Entities;

namespace VitrineAPI.Application.Mappers
{
    public class SubCategoriaMappingProfile : Profile
    {
        public SubCategoriaMappingProfile()
        {
            Map();
        }

        private void Map()
        {
            CreateMap<SubCategoria, ViewSubCategoriaDto>().ReverseMap();
            CreateMap<SubCategoria, PostSubCategoriaDto>().ReverseMap();
            CreateMap<SubCategoria, PutSubCategoriaDto>().ReverseMap();
        }
    }
}