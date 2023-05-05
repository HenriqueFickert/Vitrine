using VitrineAPI.Domain.Pagination;
using VitrineAPI.Identity.Entities;

namespace VitrineAPI.Domain.Core.Interfaces.Services
{
    public interface IUsuarioService
    {
        Task<PagedList<Usuario>> GetPaginationAsync(ParametersPalavraChave parametersPalavraChave);

        Task<Usuario> GetByIdAsync(Guid id);

        Task<Usuario> DeleteAsync(Guid id);

        bool ValidarId(Guid id);
    }
}