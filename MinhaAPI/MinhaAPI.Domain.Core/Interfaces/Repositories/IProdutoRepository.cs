using MinhaAPI.Domain.Core.Interfaces.Repositories.Base;
using MinhaAPI.Domain.Entities;
using MinhaAPI.Domain.Pagination;

namespace MinhaAPI.Domain.Core.Interfaces.Repositories
{
    public interface IProdutoRepository : IRepositoryBase<Produto>
    {
        Task<PagedList<Produto>> GetPaginationAsync(ParametersBase parametersBase);

        bool ValidarId(Guid id);
    }
}