using MinhaAPI.Application.Dtos.Base;
using MinhaAPI.Application.Dtos.Pagination;
using MinhaAPI.Application.Dtos.Produto;
using MinhaAPI.Application.Interfaces.Base;
using MinhaAPI.Domain.Entities;
using MinhaAPI.Domain.Pagination;

namespace MinhaAPI.Application.Interfaces
{
    public interface IProdutoApplication : IApplicationBase<Produto, ViewProdutoDto, PostProdutoDto, PutProdutoDto, PutStatusDto>
    {
        Task<ViewPagedListDto<Produto, ViewProdutoDto>> GetPaginationAsync(ParametersBase parametersBase);

        bool ValidarId(Guid id);
    }
}