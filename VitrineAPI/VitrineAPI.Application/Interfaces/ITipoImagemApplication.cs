using VitrineAPI.Application.Dtos.Base;
using VitrineAPI.Application.Dtos.Pagination;
using VitrineAPI.Application.Dtos.TipoImagem;
using VitrineAPI.Application.Interfaces.Base;
using VitrineAPI.Domain.Entities;
using VitrineAPI.Domain.Pagination;

namespace VitrineAPI.Application.Interfaces
{
    public interface ITipoImagemApplication : IApplicationBase<TipoImagem, ViewTipoImagemDto, PostTipoImagemDto, PutTipoImagemDto, PutStatusDto>
    {
        Task<ViewPagedListDto<TipoImagem, ViewTipoImagemDto>> GetPaginationAsync(ParametersPalavraChave parametersPalavraChave);

        bool ValidarId(Guid id);
    }
}