using AutoMapper;
using VitrineAPI.Application.Applications.Base;
using VitrineAPI.Application.Dtos.Base;
using VitrineAPI.Application.Dtos.Pagination;
using VitrineAPI.Application.Dtos.SubCategoria;
using VitrineAPI.Application.Interfaces;
using VitrineAPI.Domain.Core.Interfaces.Services;
using VitrineAPI.Domain.Core.Notifier;
using VitrineAPI.Domain.Entities;
using VitrineAPI.Domain.Pagination;

namespace VitrineAPI.Application.Applications
{
    public class SubCategoriaApplication : ApplicationBase<SubCategoria, ViewSubCategoriaDto, PostSubCategoriaDto, PutSubCategoriaDto, PutStatusDto>, ISubCategoriaApplication
    {
        private readonly ISubCategoriaService subCategoriaService;

        public SubCategoriaApplication(ISubCategoriaService subCategoriaService,
                                INotificador notificador,
                                IMapper mapper) : base(subCategoriaService, notificador, mapper)
        {
            this.subCategoriaService = subCategoriaService;
        }

        public async Task<ViewPagedListDto<SubCategoria, ViewSubCategoriaDto>> GetPaginationAsync(ParametersPalavraChave parametersPalavraChave)
        {
            PagedList<SubCategoria> pagedList = await subCategoriaService.GetPaginationAsync(parametersPalavraChave);
            return new ViewPagedListDto<SubCategoria, ViewSubCategoriaDto>(pagedList, mapper.Map<List<ViewSubCategoriaDto>>(pagedList));
        }

        public bool ValidarId(Guid id)
        {
            return subCategoriaService.ValidarId(id);
        }
    }
}