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

        public async Task<PagedList<Produto>> GetPaginationAsync(ParametersProduto parametersProduto)
        {
            return await produtoRepository.GetPaginationAsync(parametersProduto);
        }

        public bool ValidarId(Guid id)
        {
            return produtoRepository.ValidarId(id);
        }
    }
}