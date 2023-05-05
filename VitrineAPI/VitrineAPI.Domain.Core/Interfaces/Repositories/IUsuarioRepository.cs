using VitrineAPI.Domain.Pagination;
using VitrineAPI.Identity.Entities;

namespace VitrineAPI.Domain.Core.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        Task<PagedList<Usuario>> GetPaginationAsync(ParametersPalavraChave parametersPalavraChave);

        Task<Usuario> GetByIdAsync(Guid id);

        Task<Usuario> DeleteAsync(Guid id);

        bool ValidarId(Guid id);
    }
}