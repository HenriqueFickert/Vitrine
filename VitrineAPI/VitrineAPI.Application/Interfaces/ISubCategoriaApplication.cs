using VitrineAPI.Application.Dtos.Base;
using VitrineAPI.Application.Dtos.Pagination;
using VitrineAPI.Application.Dtos.SubCategoria;
using VitrineAPI.Application.Interfaces.Base;
using VitrineAPI.Domain.Entities;
using VitrineAPI.Domain.Pagination;

namespace VitrineAPI.Application.Interfaces
{
    public interface ISubCategoriaApplication : IApplicationBase<SubCategoria, ViewSubCategoriaDto, PostSubCategoriaDto, PutSubCategoriaDto, PutStatusDto>
    {
        Task<ViewPagedListDto<SubCategoria, ViewSubCategoriaDto>> GetPaginationAsync(ParametersPalavraChave parametersPalavraChave);

        bool ValidarId(Guid id);
    }
}