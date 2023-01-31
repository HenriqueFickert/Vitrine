using VitrineAPI.Domain.Core.Interfaces.Repositories;
using VitrineAPI.Domain.Core.Interfaces.Services;
using VitrineAPI.Domain.Entities;
using VitrineAPI.Domain.Pagination;
using VitrineAPI.Domain.Service.Base;

namespace VitrineAPI.Domain.Service
{
    public class ProdutoService : ServiceBase<Produto>, IProdutoService
    {
        private readonly IProdutoRepository produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository) : base(produtoRepository)
        {
            this.produtoRepository = produtoRepository;
        }

        public async Task<PagedList<Produto>> GetPaginationAsync(ParametersBase parametersBase)
        {
            return await produtoRepository.GetPaginationAsync(parametersBase);
        }

        public bool ValidarId(Guid id)
        {
            return produtoRepository.ValidarId(id);
        }
    }
}