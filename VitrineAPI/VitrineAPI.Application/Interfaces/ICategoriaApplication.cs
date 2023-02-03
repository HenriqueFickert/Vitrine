using VitrineAPI.Application.Dtos.Base;
using VitrineAPI.Application.Dtos.Categoria;
using VitrineAPI.Application.Dtos.Pagination;
using VitrineAPI.Application.Interfaces.Base;
using VitrineAPI.Domain.Entities;
using VitrineAPI.Domain.Pagination;

namespace VitrineAPI.Application.Interfaces
{
    public interface ICategoriaApplication : IApplicationBase<Categoria, ViewCategoriaDto, PostCategoriaDto, PutCategoriaDto, PutStatusDto>
    {
        Task<ViewPagedListDto<Categoria, ViewCategoriaDto>> GetPaginationAsync(ParametersPalavraChave parametersPalavraChave);

        bool ValidarId(Guid id);

        bool ValidaSubCategoriaRegistrada(PutCategoriaDto putCategoriaDto);
    }
}