using Microsoft.EntityFrameworkCore;
using VitrineAPI.Domain.Core.Interfaces.Repositories;
using VitrineAPI.Domain.Entities;
using VitrineAPI.Domain.Enum;
using VitrineAPI.Domain.Pagination;
using VitrineAPI.Infrastructure.Data.Repositories.Base;

namespace VitrineAPI.Infrastructure.Data.Repositories
{
    public class SubCategoriaRepository : RepositoryBase<SubCategoria>, ISubCategoriaRepository
    {
        private readonly AppDbContext appDbContext;

        public SubCategoriaRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<PagedList<SubCategoria>> GetPaginationAsync(ParametersBase parametersBase)
        {
            IQueryable<SubCategoria> subCategorias = appDbContext.SubCategorias.AsNoTracking();

            if (parametersBase.Id == null && parametersBase.Status == 0)
                subCategorias = subCategorias.Where(x => x.Status != Status.Excluido.ToString());
            else if (parametersBase.Status != 0)
                subCategorias = subCategorias.Where(x => x.Status == parametersBase.Status.ToString());

            if (parametersBase.Id != null)
                subCategorias = subCategorias.Where(x => parametersBase.Id.Contains(x.Id));

            subCategorias = subCategorias.OrderBy(x => x.CriadoEm);

            return await Task.FromResult(PagedList<SubCategoria>.ToPagedList(subCategorias, parametersBase.NumeroPagina, parametersBase.ResultadosExibidos));
        }

        public bool ValidarId(Guid id)
        {
            return appDbContext.SubCategorias.Any(x => x.Id == id);
        }
    }
}