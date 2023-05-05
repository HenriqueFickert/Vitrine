using AutoMapper;
using VitrineAPI.Application.Dtos.Fabricante;
using VitrineAPI.Application.Dtos.Produto;
using VitrineAPI.Application.Dtos.SubCategoria;
using VitrineAPI.Application.Dtos.Upload;
using VitrineAPI.Domain.Entities;

namespace VitrineAPI.Application.Mappers
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

            CreateMap<Upload, ReferenciaUploadDto>().ReverseMap();

            CreateMap<SubCategoria, ViewSubCategoriaDto>().ReverseMap();
            CreateMap<SubCategoria, ViewSubCategoriaDto>().ReverseMap();
            CreateMap<Fabricante, ViewFabricanteDto>().ReverseMap();
        }
    }
}