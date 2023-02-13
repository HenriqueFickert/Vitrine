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
            IQueryable<Produto> produtos = appDbContext.Produtos.Include(x => x.Fabricante)
                                                                .Include(x => x.SubCategoria)
                                                                .Include(x=>x.Uploads)
                                                                .ThenInclude(x=>x.TipoImagem).AsNoTracking();

            if (parametersBase.Id == null && parametersBase.Status == 0)
                produtos = produtos.Where(x => x.Status != Status.Excluido.ToString());
            else if (parametersBase.Status != 0)
                produtos = produtos.Where(x => x.Status == parametersBase.Status.ToString());

            if (parametersBase.Id != null)
                produtos = produtos.Where(x => parametersBase.Id.Contains(x.Id));

            produtos = produtos.OrderBy(x => x.CriadoEm);

            return await Task.FromResult(PagedList<Produto>.ToPagedList(produtos, parametersBase.NumeroPagina, parametersBase.ResultadosExibidos));
        }


        public override async Task<Produto> PostAsync(Produto produto)
        {
            return await base.PostAsync(await InserirProdutoAsync(produto));
        }

        private async Task<Produto> InserirProdutoAsync(Produto produto)
        {
            await InsertUploadsAsync(produto);
            return produto;
        }


        private async Task InsertUploadsAsync(Produto produto)
        {
            List<Upload> uploadConsultados = new List<Upload>();

            foreach (Upload upload in produto.Uploads)
            {
                Upload produtoConsultado = await appDbContext.Uploads.FindAsync(upload.Id);
                uploadConsultados.Add(produtoConsultado);
            }

            produto.AlterarUploads(uploadConsultados);
        }


        public override async Task<Produto> PutAsync(Produto produto)
        {
            return await base.PutAsync(await AtualizarProdutoAsync(produto));
        }

        private async Task<Produto> AtualizarProdutoAsync(Produto produto)
        {
            Produto produtoConsultado = await appDbContext.Produtos
                         .Include(x => x.Uploads)
                         .FirstOrDefaultAsync(x => x.Id == produto.Id);

            if (produtoConsultado is null)
                return null;

            appDbContext.Entry(produtoConsultado).CurrentValues.SetValues(produto);

            await AtualizarHashtagAsync(produto, produtoConsultado);

            return produtoConsultado;
        }

        private async Task AtualizarHashtagAsync(Produto produto, Produto produtoConsultado)
        {
            produtoConsultado.Uploads.Clear();
            foreach (Upload upload in produto.Uploads)
            {
                Upload hashtagConsultado = await appDbContext.Uploads.FindAsync(upload.Id);
                produtoConsultado.Uploads.Add(hashtagConsultado);
            }
        }

        public bool ValidarId(Guid id)
        {
            return appDbContext.Produtos.Any(x => x.Id == id);
        }
    }
}