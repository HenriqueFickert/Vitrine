using VitrineAPI.Domain.Core.Interfaces.Repositories;
using VitrineAPI.Domain.Core.Interfaces.Services;
using VitrineAPI.Domain.Entities;
using VitrineAPI.Domain.Pagination;
using VitrineAPI.Domain.Service.Base;

namespace VitrineAPI.Domain.Service
{
    public class SubCategoriaService : ServiceBase<SubCategoria>, ISubCategoriaService
    {
        private readonly ISubCategoriaRepository subCategoriaRepository;

        public SubCategoriaService(ISubCategoriaRepository subCategoriaRepository) : base(subCategoriaRepository)
        {
            this.subCategoriaRepository = subCategoriaRepository;
        }

        public async Task<PagedList<SubCategoria>> GetPaginationAsync(ParametersBase parametersBase)
        {
            return await subCategoriaRepository.GetPaginationAsync(parametersBase);
        }

        public bool ValidarId(Guid id)
        {
            return subCategoriaRepository.ValidarId(id);
        }
    }
}