using MinhaAPI.Domain.Core.Interfaces.Services.Base;
using MinhaAPI.Domain.Entities;
using MinhaAPI.Domain.Pagination;

namespace MinhaAPI.Domain.Core.Interfaces.Services
{
    public interface IProdutoService : IServiceBase<Produto>
    {
        Task<PagedList<Produto>> GetPaginationAsync(ParametersBase parametersBase);

        bool ValidarId(Guid id);
    }
}