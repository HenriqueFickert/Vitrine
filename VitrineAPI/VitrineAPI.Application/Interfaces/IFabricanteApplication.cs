using VitrineAPI.Application.Dtos.Base;
using VitrineAPI.Application.Dtos.Fabricante;
using VitrineAPI.Application.Dtos.Pagination;
using VitrineAPI.Application.Interfaces.Base;
using VitrineAPI.Domain.Entities;
using VitrineAPI.Domain.Pagination;

namespace VitrineAPI.Application.Interfaces
{
    public interface IFabricanteApplication : IApplicationBase<Fabricante, ViewFabricanteDto, PostFabricanteDto, PutFabricanteDto, PutStatusDto>
    {
        Task<ViewPagedListDto<Fabricante, ViewFabricanteDto>> GetPaginationAsync(ParametersPalavraChave parametersPalavraChave);

        bool ValidarId(Guid id);
    }
}