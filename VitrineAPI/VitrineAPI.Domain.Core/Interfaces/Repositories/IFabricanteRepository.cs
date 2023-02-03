using VitrineAPI.Domain.Core.Interfaces.Repositories.Base;
using VitrineAPI.Domain.Entities;
using VitrineAPI.Domain.Pagination;

namespace VitrineAPI.Domain.Core.Interfaces.Repositories
{
    public interface IFabricanteRepository : IRepositoryBase<Fabricante>
    {
        Task<PagedList<Fabricante>> GetPaginationAsync(ParametersBase parametersBase);

        bool ValidarId(Guid id);
    }
}