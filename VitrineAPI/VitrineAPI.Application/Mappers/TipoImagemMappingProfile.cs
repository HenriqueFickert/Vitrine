using AutoMapper;
using VitrineAPI.Application.Dtos.TipoImagem;
using VitrineAPI.Domain.Entities;

namespace VitrineAPI.Application.Mappers
{
    public class TipoImagemMappingProfile : Profile
    {
        public TipoImagemMappingProfile()
        {
            Map();
        }

        private void Map()
        {
            CreateMap<TipoImagem, ViewTipoImagemDto>().ReverseMap();
            CreateMap<TipoImagem, PostTipoImagemDto>().ReverseMap();
            CreateMap<TipoImagem, PutTipoImagemDto>().ReverseMap();
        }
    }
}