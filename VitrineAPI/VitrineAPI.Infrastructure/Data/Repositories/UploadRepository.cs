using Microsoft.EntityFrameworkCore;
using VitrineAPI.Domain.Core.Interfaces.Repositories;
using VitrineAPI.Domain.Entities;
using VitrineAPI.Domain.Enum;
using VitrineAPI.Domain.Pagination;
using VitrineAPI.Infrastructure.Data.Repositories.Base;

namespace VitrineAPI.Infrastructure.Data.Repositories
{
    public class UploadRepository : RepositoryBase<Upload>, IUploadRepository
    {
        private readonly AppDbContext appDbContext;

        public UploadRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<PagedList<Upload>> GetPaginationAsync(ParametersPalavraChave parametersPalavraChave)
        {
            IQueryable<Upload> uploads = appDbContext.Uploads.Include(x=> x.TipoImagem).AsNoTracking();

            if (parametersPalavraChave.Id == null && parametersPalavraChave.Status == 0)
                uploads = uploads.Where(x => x.Status != Status.Excluido.ToString());
            else if (parametersPalavraChave.Status != 0)
                uploads = uploads.Where(x => x.Status == parametersPalavraChave.Status.ToString());

            if (parametersPalavraChave.Id != null)
                uploads = uploads.Where(x => parametersPalavraChave.Id.Contains(x.Id));

            uploads = uploads.OrderBy(x => x.CriadoEm);

            return await Task.FromResult(PagedList<Upload>.ToPagedList(uploads, parametersPalavraChave.NumeroPagina, parametersPalavraChave.ResultadosExibidos));
        }

        public bool ValidarId(Guid id)
        {
            return appDbContext.Uploads.Any(x => x.Id == id);
        }
    }
}