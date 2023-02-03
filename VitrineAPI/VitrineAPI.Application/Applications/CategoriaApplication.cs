using AutoMapper;
using VitrineAPI.Application.Applications.Base;
using VitrineAPI.Application.Dtos.Base;
using VitrineAPI.Application.Dtos.Categoria;
using VitrineAPI.Application.Dtos.Pagination;
using VitrineAPI.Application.Interfaces;
using VitrineAPI.Domain.Core.Interfaces.Services;
using VitrineAPI.Domain.Core.Notifier;
using VitrineAPI.Domain.Entities;
using VitrineAPI.Domain.Pagination;

namespace VitrineAPI.Application.Applications
{
    public class CategoriaApplication : ApplicationBase<Categoria, ViewCategoriaDto, PostCategoriaDto, PutCategoriaDto, PutStatusDto>, ICategoriaApplication
    {
        private readonly ICategoriaService categoriaService;

        public CategoriaApplication(ICategoriaService categoriaService,
                               INotificador notificador,
                               IMapper mapper) : base(categoriaService, notificador, mapper)
        {
            this.categoriaService = categoriaService;
        }

        public async Task<ViewPagedListDto<Categoria, ViewCategoriaDto>> GetPaginationAsync(ParametersPalavraChave parametersPalavraChave)
        {
            PagedList<Categoria> pagedList = await categoriaService.GetPaginationAsync(parametersPalavraChave);
            return new ViewPagedListDto<Categoria, ViewCategoriaDto>(pagedList, mapper.Map<List<ViewCategoriaDto>>(pagedList));
        }

        public bool ValidarId(Guid id)
        {
            return categoriaService.ValidarId(id);
        }

        public bool ValidaSubCategoriaRegistrada(PutCategoriaDto putCategoriaDto)
        {
            return mapper.Map<bool>(categoriaService.ValidaSubCategoriaRegistrada(mapper.Map<Categoria>(putCategoriaDto)));
        }
    }
}