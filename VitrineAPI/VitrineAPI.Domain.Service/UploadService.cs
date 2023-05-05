using VitrineAPI.Domain.Core.Interfaces.Repositories;
using VitrineAPI.Domain.Core.Interfaces.Services;
using VitrineAPI.Domain.Entities;
using VitrineAPI.Domain.Pagination;
using VitrineAPI.Domain.Service.Base;

namespace VitrineAPI.Domain.Service
{
    public class UploadService : ServiceBase<Upload>, IUploadService
    {
        private readonly IUploadRepository uploadRepository;

        public UploadService(IUploadRepository uploadRepository) : base(uploadRepository)
        {
            this.uploadRepository = uploadRepository;
        }

        public async Task<PagedList<Upload>> GetPaginationAsync(ParametersPalavraChave parametersPalavraChave)
        {
            return await uploadRepository.GetPaginationAsync(parametersPalavraChave);
        }

        public bool ValidarId(Guid id)
        {
            return uploadRepository.ValidarId(id);
        }
    }
}