using VitrineAPI.Domain.Core.Interfaces.Services.Base;
using VitrineAPI.Domain.Entities;
using VitrineAPI.Domain.Pagination;

namespace VitrineAPI.Domain.Core.Interfaces.Services
{
    public interface ISubCategoriaService : IServiceBase<SubCategoria>
    {
        Task<PagedList<SubCategoria>> GetPaginationAsync(ParametersBase parametersBase);

        bool ValidarId(Guid id);
    }
}