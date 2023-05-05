using VitrineAPI.Domain.Core.Interfaces.Repositories.Base;
using VitrineAPI.Domain.Entities;
using VitrineAPI.Domain.Pagination;

namespace VitrineAPI.Domain.Core.Interfaces.Repositories
{
    public interface IUploadRepository : IRepositoryBase<Upload>
    {
        Task<PagedList<Upload>> GetPaginationAsync(ParametersPalavraChave parametersPalavraChave);

        bool ValidarId(Guid id);
    }
}