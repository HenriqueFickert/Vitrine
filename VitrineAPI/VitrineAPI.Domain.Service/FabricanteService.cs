using VitrineAPI.Domain.Core.Interfaces.Repositories;
using VitrineAPI.Domain.Core.Interfaces.Services;
using VitrineAPI.Domain.Entities;
using VitrineAPI.Domain.Pagination;
using VitrineAPI.Domain.Service.Base;

namespace VitrineAPI.Domain.Service
{
    public class FabricanteService : ServiceBase<Fabricante>, IFabricanteService
    {
        private readonly IFabricanteRepository fabricanteRepository;

        public FabricanteService(IFabricanteRepository fabricanteRepository) : base(fabricanteRepository)
        {
            this.fabricanteRepository = fabricanteRepository;
        }

        public async Task<PagedList<Fabricante>> GetPaginationAsync(ParametersBase parametersBase)
        {
            return await fabricanteRepository.GetPaginationAsync(parametersBase);
        }

        public bool ValidarId(Guid id)
        {
            return fabricanteRepository.ValidarId(id);
        }
    }
}