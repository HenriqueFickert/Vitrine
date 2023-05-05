using VitrineAPI.Domain.Core.Interfaces.Services.Base;
using VitrineAPI.Domain.Entities;
using VitrineAPI.Domain.Pagination;

namespace VitrineAPI.Domain.Core.Interfaces.Services
{
    public interface ICategoriaService : IServiceBase<Categoria>
    {
        Task<PagedList<Categoria>> GetPaginationAsync(ParametersPalavraChave parametersPalavraChave);

        bool ValidaSubCategoriaRegistrada(Categoria categoria);

        bool ValidarId(Guid id);
    }
}