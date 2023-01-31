using Microsoft.EntityFrameworkCore;
using VitrineAPI.Domain.Core.Interfaces.Repositories;
using VitrineAPI.Domain.Entities;
using VitrineAPI.Domain.Enum;
using VitrineAPI.Domain.Pagination;
using VitrineAPI.Infrastructure.Data.Repositories.Base;

namespace VitrineAPI.Infrastructure.Data.Repositories
{
    public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
    {
        private readonly AppDbContext appDbContext;

        public ProdutoRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<PagedList<Produto>> GetPaginationAsync(ParametersBase parametersBase)
        {
            IQueryable<Produto> produtos = appDbContext.Produtos.AsNoTracking();

            if (parametersBase.Id == null && parametersBase.Status == 0)
                produtos = produtos.Where(x => x.Status != Status.Excluido.ToString());
            else if (parametersBase.Status != 0)
                produtos = produtos.Where(x => x.Status == parametersBase.Status.ToString());

            if (parametersBase.Id != null)
                produtos = produtos.Where(x => parametersBase.Id.Contains(x.Id));

            produtos = produtos.OrderBy(x => x.CriadoEm);

            return await Task.FromResult(PagedList<Produto>.ToPagedList(produtos, parametersBase.NumeroPagina, parametersBase.ResultadosExibidos));
        }

        public bool ValidarId(Guid id)
        {
            return appDbContext.Produtos.Any(x => x.Id == id);
        }
    }
}