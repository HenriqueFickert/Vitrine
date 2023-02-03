using VitrineAPI.Domain.Core.Interfaces.Repositories.Base;
using VitrineAPI.Domain.Entities;
using VitrineAPI.Domain.Pagination;

namespace VitrineAPI.Domain.Core.Interfaces.Repositories
{
    public interface ICategoriaRepository : IRepositoryBase<Categoria>
    {
        Task<PagedList<Categoria>> GetPaginationAsync(ParametersPalavraChave parametersPalavraChave);

        bool ValidaSubCategoriaRegistrada(Categoria categoria);

        bool ValidarId(Guid id);
    }
}