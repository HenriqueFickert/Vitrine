using VitrineAPI.Domain.Entities;
using VitrineAPI.Domain.Pagination;

namespace VitrineAPI.Domain.Core.Interfaces.Repositories
{
    public interface ISubCategoriaRepository
    {
        Task<PagedList<SubCategoria>> GetPaginationAsync(ParametersBase parametersBase);

        bool ValidarId(Guid id);
    }
}