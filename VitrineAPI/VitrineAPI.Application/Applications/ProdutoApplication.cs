using AutoMapper;
using VitrineAPI.Application.Applications.Base;
using VitrineAPI.Application.Dtos.Base;
using VitrineAPI.Application.Dtos.Pagination;
using VitrineAPI.Application.Dtos.Produto;
using VitrineAPI.Application.Interfaces;
using VitrineAPI.Domain.Core.Interfaces.Services;
using VitrineAPI.Domain.Core.Notifier;
using VitrineAPI.Domain.Entities;
using VitrineAPI.Domain.Pagination;

namespace VitrineAPI.Application.Applications
{
    public class ProdutoApplication : ApplicationBase<Produto, ViewProdutoDto, PostProdutoDto, PutProdutoDto, PutStatusDto>, IProdutoApplication
    {
        private readonly IProdutoService produtoService;
        private readonly IUploadApplication uploadApplication;

        public ProdutoApplication(IProdutoService produtoService,
                                INotificador notificador,
                                IMapper mapper) : base(produtoService, notificador, mapper)
        {
            this.produtoService = produtoService;
        }

        public async Task<ViewPagedListDto<Produto, ViewProdutoDto>> GetPaginationAsync(ParametersProduto parametersProduto)
        {
            PagedList<Produto> pagedList = await produtoService.GetPaginationAsync(parametersProduto);
            return new ViewPagedListDto<Produto, ViewProdutoDto>(pagedList, mapper.Map<List<ViewProdutoDto>>(pagedList));
        }

        public bool ValidarId(Guid id)
        {
            return produtoService.ValidarId(id);
        }
    }
}