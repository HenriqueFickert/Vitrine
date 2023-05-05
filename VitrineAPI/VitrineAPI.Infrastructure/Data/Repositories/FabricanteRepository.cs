using Microsoft.EntityFrameworkCore;
using VitrineAPI.Domain.Core.Interfaces.Repositories;
using VitrineAPI.Domain.Entities;
using VitrineAPI.Domain.Enum;
using VitrineAPI.Domain.Pagination;
using VitrineAPI.Infrastructure.Data.Repositories.Base;

namespace VitrineAPI.Infrastructure.Data.Repositories
{
    public class FabricanteRepository : RepositoryBase<Fabricante>, IFabricanteRepository
    {
        private readonly AppDbContext appDbContext;

        public FabricanteRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<PagedList<Fabricante>> GetPaginationAsync(ParametersBase parametersBase)
        {
            IQueryable<Fabricante> fabricantes = appDbContext.Fabricantes.AsNoTracking();

            if (parametersBase.Id == null && parametersBase.Status == 0)
                fabricantes = fabricantes.Where(x => x.Status != Status.Excluido.ToString());
            else if (parametersBase.Status != 0)
                fabricantes = fabricantes.Where(x => x.Status == parametersBase.Status.ToString());

            if (parametersBase.Id != null)
                fabricantes = fabricantes.Where(x => parametersBase.Id.Contains(x.Id));

            fabricantes = fabricantes.OrderBy(x => x.CriadoEm);

            return await Task.FromResult(PagedList<Fabricante>.ToPagedList(fabricantes, parametersBase.NumeroPagina, parametersBase.ResultadosExibidos));
        }

        public bool ValidarId(Guid id)
        {
            return appDbContext.Fabricantes.Any(x => x.Id == id);
        }
    }
}