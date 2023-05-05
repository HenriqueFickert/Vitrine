using VitrineAPI.Application.Dtos.Base;
using VitrineAPI.Application.Dtos.Pagination;
using VitrineAPI.Application.Dtos.Produto;
using VitrineAPI.Application.Dtos.Upload;
using VitrineAPI.Application.Interfaces.Base;
using VitrineAPI.Domain.Entities;
using VitrineAPI.Domain.Pagination;

namespace VitrineAPI.Application.Interfaces
{
    public interface IUploadApplication : IApplicationBase<Upload, ViewUploadDto, PostUploadDto, PutUploadDto, PutStatusDto>
    {
        Task<ViewPagedListDto<Upload, ViewUploadDto>> GetPaginationAsync(ParametersPalavraChave parametersPalavraChave);

        Task<ViewUploadDto> PostAsync(PostUploadDto postUploadDto, string caminhoFisico, string caminhoAbsoluto, string splitRelativo);

        Task<ViewUploadDto> PutAsync(PutUploadDto putUploadDto, string caminhoFisico, string caminhoAbsoluto, string splitRelativo);

        bool ValidarId(Guid id);
    }
}