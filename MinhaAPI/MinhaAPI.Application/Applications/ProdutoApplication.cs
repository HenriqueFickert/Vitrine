using AutoMapper;
using MinhaAPI.Application.Applications.Base;
using MinhaAPI.Application.Dtos.Base;
using MinhaAPI.Application.Dtos.Pagination;
using MinhaAPI.Application.Dtos.Produto;
using MinhaAPI.Application.Interfaces;
using MinhaAPI.Domain.Core.Interfaces.Services;
using MinhaAPI.Domain.Core.Notifier;
using MinhaAPI.Domain.Entities;
using MinhaAPI.Domain.Pagination;

namespace MinhaAPI.Application.Applications
{
    public class ProdutoApplication : ApplicationBase<Produto, ViewProdutoDto, PostProdutoDto, PutProdutoDto, PutStatusDto>, IProdutoApplication
    {
        private readonly IProdutoService produtoService;

        public ProdutoApplication(IProdutoService produtoService,
                                INotificador notificador,
                                IMapper mapper) : base(produtoService, notificador, mapper)
        {
            this.produtoService = produtoService;
        }

        public async Task<ViewPagedListDto<Produto, ViewProdutoDto>> GetPaginationAsync(ParametersBase parametersBase)
        {
            PagedList<Produto> pagedList = await produtoService.GetPaginationAsync(parametersBase);
            return new ViewPagedListDto<Produto, ViewProdutoDto>(pagedList, mapper.Map<List<ViewProdutoDto>>(pagedList));
        }

        public bool ValidarId(Guid id)
        {
            return produtoService.ValidarId(id);
        }
    }
}