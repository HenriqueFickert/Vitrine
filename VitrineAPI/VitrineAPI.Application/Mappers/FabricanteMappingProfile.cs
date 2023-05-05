using AutoMapper;
using VitrineAPI.Application.Dtos.Fabricante;
using VitrineAPI.Domain.Entities;

namespace VitrineAPI.Application.Mappers
{
    public class FabricanteMappingProfile : Profile
    {
        public FabricanteMappingProfile()
        {
            Map();
        }

        private void Map()
        {
            CreateMap<Fabricante, ViewFabricanteDto>().ReverseMap();
            CreateMap<Fabricante, PostFabricanteDto>().ReverseMap();
            CreateMap<Fabricante, PutFabricanteDto>().ReverseMap();
        }
    }
}