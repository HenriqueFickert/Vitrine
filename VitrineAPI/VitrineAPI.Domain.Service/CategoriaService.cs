using VitrineAPI.Domain.Core.Interfaces.Repositories;
using VitrineAPI.Domain.Core.Interfaces.Services;
using VitrineAPI.Domain.Entities;
using VitrineAPI.Domain.Pagination;
using VitrineAPI.Domain.Service.Base;

namespace VitrineAPI.Domain.Service
{
    public class CategoriaService : ServiceBase<Categoria>, ICategoriaService
    {
        private readonly ICategoriaRepository categoriaRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository) : base(categoriaRepository)
        {
            this.categoriaRepository = categoriaRepository;
        }

        public async Task<PagedList<Categoria>> GetPaginationAsync(ParametersPalavraChave parametersPalavraChave)
        {
            return await categoriaRepository.GetPaginationAsync(parametersPalavraChave);
        }

        public bool ValidaSubCategoriaRegistrada(Categoria categoria)
        {
            return categoriaRepository.ValidaSubCategoriaRegistrada(categoria);
        }

        public bool ValidarId(Guid id)
        {
            return categoriaRepository.ValidarId(id);
        }
    }
}