using MinhaAPI.Domain.Core.Interfaces.Repositories;
using MinhaAPI.Domain.Core.Interfaces.Services;
using MinhaAPI.Domain.Entities;
using MinhaAPI.Domain.Pagination;
using MinhaAPI.Domain.Service.Base;

namespace MinhaAPI.Domain.Service
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