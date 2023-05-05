using VitrineAPI.Domain.Core.Interfaces.Repositories;
using VitrineAPI.Domain.Core.Interfaces.Services;
using VitrineAPI.Domain.Entities;
using VitrineAPI.Domain.Pagination;
using VitrineAPI.Domain.Service.Base;

namespace VitrineAPI.Domain.Service
{
    public class TipoImagemService : ServiceBase<TipoImagem>, ITipoImagemService
    {
        private readonly ITipoImagemRepository tipoImagemRepository;

        public TipoImagemService(ITipoImagemRepository tipoImagemRepository) : base(tipoImagemRepository)
        {
            this.tipoImagemRepository = tipoImagemRepository;
        }

        public async Task<PagedList<TipoImagem>> GetPaginationAsync(ParametersPalavraChave parametersPalavraChave)
        {
            return await tipoImagemRepository.GetPaginationAsync(parametersPalavraChave);
        }

        public bool ValidarId(Guid id)
        {
            return tipoImagemRepository.ValidarId(id);
        }
    }
}