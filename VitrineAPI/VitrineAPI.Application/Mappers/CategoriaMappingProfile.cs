using AutoMapper;
using VitrineAPI.Application.Dtos.Categoria;
using VitrineAPI.Application.Dtos.SubCategoria;
using VitrineAPI.Domain.Entities;

namespace VitrineAPI.Application.Mappers
{
    public class CategoriaMappingProfile : Profile
    {
        public CategoriaMappingProfile()
        {
            Map();
        }

        private void Map()
        {
            CreateMap<Categoria, ViewCategoriaDto>().ReverseMap();
            CreateMap<Categoria, PostCategoriaDto>().ReverseMap();
            CreateMap<Categoria, PutCategoriaDto>().ReverseMap();

            CreateMap<SubCategoria, ReferenciaSubCategoriaDto>().ReverseMap();
        }
    }
}