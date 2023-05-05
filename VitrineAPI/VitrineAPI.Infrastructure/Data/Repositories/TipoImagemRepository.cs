using Microsoft.EntityFrameworkCore;
using VitrineAPI.Domain.Core.Interfaces.Repositories;
using VitrineAPI.Domain.Entities;
using VitrineAPI.Domain.Enum;
using VitrineAPI.Domain.Pagination;
using VitrineAPI.Infrastructure.Data.Repositories.Base;

namespace VitrineAPI.Infrastructure.Data.Repositories
{
    public class TipoImagemRepository : RepositoryBase<TipoImagem>, ITipoImagemRepository
    {
        private readonly AppDbContext appDbContext;

        public TipoImagemRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<PagedList<TipoImagem>> GetPaginationAsync(ParametersPalavraChave parametersPalavraChave)
        {
            IQueryable<TipoImagem> tipoImagens = appDbContext.TipoImagens.AsNoTracking();

            if (parametersPalavraChave.Id == null && parametersPalavraChave.Status == 0)
                tipoImagens = tipoImagens.Where(x => x.Status != Status.Excluido.ToString());
            else if (parametersPalavraChave.Status != 0)
                tipoImagens = tipoImagens.Where(x => x.Status == parametersPalavraChave.Status.ToString());

            if (parametersPalavraChave.Id != null)
                tipoImagens = tipoImagens.Where(x => parametersPalavraChave.Id.Contains(x.Id));

            tipoImagens = tipoImagens.OrderBy(x => x.CriadoEm);

            return await Task.FromResult(PagedList<TipoImagem>.ToPagedList(tipoImagens, parametersPalavraChave.NumeroPagina, parametersPalavraChave.ResultadosExibidos));
        }

        public bool ValidarId(Guid id)
        {
            return appDbContext.TipoImagens.Any(x => x.Id == id);
        }
    }
}