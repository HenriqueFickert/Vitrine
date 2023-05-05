using VitrineAPI.Domain.Core.Interfaces.Services.Base;
using VitrineAPI.Domain.Entities;
using VitrineAPI.Domain.Pagination;

namespace VitrineAPI.Domain.Core.Interfaces.Services
{
    public interface IProdutoService : IServiceBase<Produto>
    {
        Task<PagedList<Produto>> GetPaginationAsync(ParametersProduto parametersProduto);

        bool ValidarId(Guid id);
    }
}