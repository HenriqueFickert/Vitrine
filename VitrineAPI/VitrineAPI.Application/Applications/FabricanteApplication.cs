using AutoMapper;
using VitrineAPI.Application.Applications.Base;
using VitrineAPI.Application.Dtos.Base;
using VitrineAPI.Application.Dtos.Fabricante;
using VitrineAPI.Application.Dtos.Pagination;
using VitrineAPI.Application.Interfaces;
using VitrineAPI.Domain.Core.Interfaces.Services;
using VitrineAPI.Domain.Core.Notifier;
using VitrineAPI.Domain.Entities;
using VitrineAPI.Domain.Pagination;

namespace VitrineAPI.Application.Applications
{
    public class FabricanteApplication : ApplicationBase<Fabricante, ViewFabricanteDto, PostFabricanteDto, PutFabricanteDto, PutStatusDto>, IFabricanteApplication
    {
        private readonly IFabricanteService fabricanteService;

        public FabricanteApplication(IFabricanteService fabricanteService,
                                INotificador notificador,
                                IMapper mapper) : base(fabricanteService, notificador, mapper)
        {
            this.fabricanteService = fabricanteService;
        }

        public async Task<ViewPagedListDto<Fabricante, ViewFabricanteDto>> GetPaginationAsync(ParametersPalavraChave parametersPalavraChave)
        {
            PagedList<Fabricante> pagedList = await fabricanteService.GetPaginationAsync(parametersPalavraChave);
            return new ViewPagedListDto<Fabricante, ViewFabricanteDto>(pagedList, mapper.Map<List<ViewFabricanteDto>>(pagedList));
        }

        public bool ValidarId(Guid id)
        {
            return fabricanteService.ValidarId(id);
        }
    }
}