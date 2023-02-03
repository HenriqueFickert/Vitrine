using VitrineAPI.Domain.Core.Interfaces.Repositories.Base;
using VitrineAPI.Domain.Entities;
using VitrineAPI.Domain.Pagination;

namespace VitrineAPI.Domain.Core.Interfaces.Repositories
{
    public interface ISubCategoriaRepository : IRepositoryBase<SubCategoria>
    {
        Task<PagedList<SubCategoria>> GetPaginationAsync(ParametersBase parametersBase);

        bool ValidarId(Guid id);
    }
}