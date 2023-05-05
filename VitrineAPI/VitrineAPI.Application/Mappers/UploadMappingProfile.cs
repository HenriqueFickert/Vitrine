using AutoMapper;
using VitrineAPI.Application.Dtos.Upload;
using VitrineAPI.Domain.Entities;

namespace VitrineAPI.Application.Mappers
{
    public class UploadMappingProfile : Profile
    {
        public UploadMappingProfile()
        {
            Map();
        }

        private void Map()
        {
            CreateMap<Upload, ViewUploadDto>().ReverseMap();
            CreateMap<Upload, PostUploadDto>().ReverseMap();
            CreateMap<Upload, PutUploadDto>().ReverseMap();
        }
    }
}