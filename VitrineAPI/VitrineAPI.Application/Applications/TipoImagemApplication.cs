using AutoMapper;
using VitrineAPI.Application.Applications.Base;
using VitrineAPI.Application.Dtos.Base;
using VitrineAPI.Application.Dtos.Pagination;
using VitrineAPI.Application.Dtos.TipoImagem;
using VitrineAPI.Application.Interfaces;
using VitrineAPI.Domain.Core.Interfaces.Services;
using VitrineAPI.Domain.Core.Notifier;
using VitrineAPI.Domain.Entities;
using VitrineAPI.Domain.Pagination;

namespace VitrineAPI.Application.Applications
{
    public class TipoImagemApplication : ApplicationBase<TipoImagem, ViewTipoImagemDto, PostTipoImagemDto, PutTipoImagemDto, PutStatusDto>, ITipoImagemApplication
    {
        private readonly ITipoImagemService uploadService;

        public TipoImagemApplication(ITipoImagemService uploadService,
                                     INotificador notificador,
                                     IMapper mapper) : base(uploadService, notificador, mapper)
        {
            this.uploadService = uploadService;
        }

        public async Task<ViewPagedListDto<TipoImagem, ViewTipoImagemDto>> GetPaginationAsync(ParametersPalavraChave parametersPalavraChave)
        {
            PagedList<TipoImagem> pagedList = await uploadService.GetPaginationAsync(parametersPalavraChave);
            return new ViewPagedListDto<TipoImagem, ViewTipoImagemDto>(pagedList, mapper.Map<List<ViewTipoImagemDto>>(pagedList));
        }

        public bool ValidarId(Guid id)
        {
            return uploadService.ValidarId(id);
        }
    }
}