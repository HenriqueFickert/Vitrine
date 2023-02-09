using Microsoft.EntityFrameworkCore;
using VitrineAPI.Domain.Core.Interfaces.Repositories;
using VitrineAPI.Domain.Entities;
using VitrineAPI.Domain.Enum;
using VitrineAPI.Domain.Pagination;
using VitrineAPI.Infrastructure.Data.Repositories.Base;

namespace VitrineAPI.Infrastructure.Data.Repositories
{
    public class CategoriaRepository : RepositoryBase<Categoria>, ICategoriaRepository
    {
        private readonly AppDbContext appDbContext;

        public CategoriaRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<PagedList<Categoria>> GetPaginationAsync(ParametersPalavraChave parametersPalavraChave)
        {
            IQueryable<Categoria> Categorias = appDbContext.Categorias.Include(menu => menu.SubCategorias).AsNoTracking();

            if (parametersPalavraChave.PalavraChave == null && parametersPalavraChave.Id == null && parametersPalavraChave.Status == 0)
                Categorias = Categorias.Where(x => x.Status != Status.Excluido.ToString());
            else if (parametersPalavraChave.Status != 0)
                Categorias = Categorias.Where(x => x.Status == parametersPalavraChave.Status.ToString());

            if (!string.IsNullOrEmpty(parametersPalavraChave.PalavraChave))
                Categorias = Categorias.Where(x => EF.Functions.Like(x.Nome, $"%{parametersPalavraChave.PalavraChave}%"));

            if (parametersPalavraChave.Id != null)
                Categorias = Categorias.Where(x => parametersPalavraChave.Id.Contains(x.Id));

            return await Task.FromResult(PagedList<Categoria>.ToPagedList(Categorias, parametersPalavraChave.NumeroPagina, parametersPalavraChave.ResultadosExibidos));
        }

        public override async Task<Categoria> PostAsync(Categoria categoria)
        {
            return await base.PostAsync(InserCategoriaAsync(categoria));
        }

        private Categoria InserCategoriaAsync(Categoria categoria)
        {
            categoria.ListaSubcategoria(categoria.SubCategorias.Select(subCategoria => appDbContext.SubCategorias.Find(subCategoria.Id)).ToList());
            return categoria;
        }

        public override async Task<Categoria> PutAsync(Categoria categoria)
        {
            return await base.PutAsync(await UpdateMesaAsync(categoria));
        }

        private async Task<Categoria> UpdateMesaAsync(Categoria categoria)
        {
            Categoria categoriaConsultada = await appDbContext.Categorias
                                                 .Include(p => p.SubCategorias)
                                                 .FirstOrDefaultAsync(p => p.Id == categoria.Id);
            if (categoriaConsultada == null)
                return null;

            await UpdateSubCategoriaAsync(categoria, categoriaConsultada);

            return categoriaConsultada;
        }

        private async Task UpdateSubCategoriaAsync(Categoria categoria, Categoria categoriaConsultada)
        {
            categoriaConsultada.SubCategorias.Clear();
            foreach (SubCategoria subcategoria in categoria.SubCategorias)
            {
                SubCategoria cadeiraConsultada = await appDbContext.SubCategorias.FindAsync(subcategoria.Id);
                categoriaConsultada.SubCategorias.Add(cadeiraConsultada);
            }
        }

        public bool ValidarId(Guid id)
        {
            return appDbContext.Categorias.Any(x => x.Id == id);
        }

        public bool ValidaSubCategoriaRegistrada(Categoria categoria)
        {
            Categoria consulta = appDbContext.Categorias
                          .AsNoTracking()
                          .Include(p => p.SubCategorias)
                          .FirstOrDefault(p => p.Id == categoria.Id);

            if (consulta == null)
                return false;

            return consulta.SubCategorias.Any(e => categoria.SubCategorias.Any(x => x.Id == e.Id));
        }
    }
}