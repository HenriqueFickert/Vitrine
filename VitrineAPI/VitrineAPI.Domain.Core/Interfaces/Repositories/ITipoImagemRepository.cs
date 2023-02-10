using VitrineAPI.Domain.Core.Interfaces.Repositories.Base;
using VitrineAPI.Domain.Entities;
using VitrineAPI.Domain.Pagination;

namespace VitrineAPI.Domain.Core.Interfaces.Repositories
{
    public interface ITipoImagemRepository : IRepositoryBase<TipoImagem>
    {
        Task<PagedList<TipoImagem>> GetPaginationAsync(ParametersPalavraChave parametersPalavraChave);

        bool ValidarId(Guid id);
    }
}