using Microsoft.EntityFrameworkCore;
using VitrineAPI.Domain.Core.Interfaces.Repositories;
using VitrineAPI.Domain.Enum;
using VitrineAPI.Domain.Pagination;
using VitrineAPI.Identity.Data;
using VitrineAPI.Identity.Entities;

namespace VitrineAPI.Infrastructure.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IdentityDataContext identityDataContext;

        public UsuarioRepository(IdentityDataContext identityDataContext)
        {
            this.identityDataContext = identityDataContext;
        }

        public async Task<PagedList<Usuario>> GetPaginationAsync(ParametersPalavraChave parametersPalavraChave)
        {
            IQueryable<Usuario> usuario = identityDataContext.Users.AsNoTracking();

            if (parametersPalavraChave.PalavraChave == null && parametersPalavraChave.Id == null && parametersPalavraChave.Status == 0)
                usuario = usuario.Where(x => x.Status != Status.Excluido.ToString());
            else if (parametersPalavraChave.Status != 0)
                usuario = usuario.Where(x => x.Status == parametersPalavraChave.Status.ToString());

            if (!string.IsNullOrEmpty(parametersPalavraChave.PalavraChave))
                usuario = usuario.Where(x => EF.Functions.Like(x.Nome, $"%{parametersPalavraChave.PalavraChave}%"));

            if (parametersPalavraChave.Id != null)
            {
                string[] guids = parametersPalavraChave.Id.Select(x => x.ToString()).ToArray();
                usuario = usuario.Where(x => guids.Contains(x.Id));
            }

            usuario = usuario.OrderByDescending(usuario => usuario.CriadoEm);

            return await Task.FromResult(PagedList<Usuario>.ToPagedList(usuario, parametersPalavraChave.NumeroPagina, parametersPalavraChave.ResultadosExibidos));
        }

        public async Task<Usuario> GetByIdAsync(Guid id)
        {
            return await identityDataContext.Users.FindAsync(id.ToString());
        }

        public async Task<Usuario> DeleteAsync(Guid id)
        {
            Usuario consultado = await identityDataContext.Users.FindAsync(id.ToString());

            if (consultado is null)
                return null;

            var removido = identityDataContext.Remove(consultado);
            await identityDataContext.SaveChangesAsync();

            return removido.Entity;
        }

        public bool ValidarId(Guid id)
        {
            return identityDataContext.Users.Any(x => x.Id == id.ToString());
        }
    }
}