using VitrineAPI.Domain.Core.Interfaces.Services.Base;
using VitrineAPI.Domain.Entities;
using VitrineAPI.Domain.Pagination;

namespace VitrineAPI.Domain.Core.Interfaces.Services
{
    public interface ITipoImagemService : IServiceBase<TipoImagem>
    {
        Task<PagedList<TipoImagem>> GetPaginationAsync(ParametersPalavraChave parametersPalavraChave);

        bool ValidarId(Guid id);
    }
}