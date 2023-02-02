using AutoMapper;
using VitrineAPI.Application.Dtos.Identity.Usuario;
using VitrineAPI.Identity.Entities;

namespace VitrineAPI.Application.Mappers
{
    public class UsuarioMappingProfile : Profile
    {
        public UsuarioMappingProfile()
        {
            Map();
        }

        private void Map()
        {
            CreateMap<Usuario, ViewUsuarioDto>().ReverseMap();
        }
    }
}