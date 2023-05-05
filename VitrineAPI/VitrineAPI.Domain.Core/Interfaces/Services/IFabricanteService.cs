using VitrineAPI.Domain.Core.Interfaces.Services.Base;
using VitrineAPI.Domain.Entities;
using VitrineAPI.Domain.Pagination;

namespace VitrineAPI.Domain.Core.Interfaces.Services
{
    public interface IFabricanteService : IServiceBase<Fabricante>
    {
        Task<PagedList<Fabricante>> GetPaginationAsync(ParametersBase parametersBase);

        bool ValidarId(Guid id);
    }
}