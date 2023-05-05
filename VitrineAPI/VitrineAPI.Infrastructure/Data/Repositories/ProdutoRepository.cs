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

        public async Task<PagedList<Produto>> GetPaginationAsync(ParametersProduto parametersProduto)
        {
            IQueryable<Produto> produtos = appDbContext.Produtos.Include(x => x.Fabricante)
                                                                .Include(x => x.SubCategoria)
                                                                .Include(x=>x.Uploads)
                                                                .ThenInclude(x=>x.TipoImagem).AsNoTracking();

            if (parametersProduto.Id == null && parametersProduto.Status == 0)
                produtos = produtos.Where(x => x.Status != Status.Excluido.ToString());
            else if (parametersProduto.Status != 0)
                produtos = produtos.Where(x => x.Status == parametersProduto.Status.ToString());

            if (!string.IsNullOrEmpty(parametersProduto.PalavraChave))
                produtos = produtos.Where(programa => EF.Functions.Like(programa.Nome, $"%{parametersProduto.PalavraChave}%"));

            if (parametersProduto.Id != null)
                produtos = produtos.Where(x => parametersProduto.Id.Contains(x.Id));

            if (parametersProduto.subcategoriasId != null)
                produtos = produtos.Where(x => parametersProduto.subcategoriasId.Contains(x.SubCategoriaId));

            produtos = produtos.OrderBy(x => x.CriadoEm);

            return await Task.FromResult(PagedList<Produto>.ToPagedList(produtos, parametersProduto.NumeroPagina, parametersProduto.ResultadosExibidos));
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
            List<Upload> uploadConsultados = new ();

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