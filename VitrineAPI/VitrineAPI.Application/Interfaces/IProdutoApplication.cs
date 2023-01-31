using VitrineAPI.Application.Dtos.Base;
using VitrineAPI.Application.Dtos.Pagination;
using VitrineAPI.Application.Dtos.Produto;
using VitrineAPI.Application.Interfaces.Base;
using VitrineAPI.Domain.Entities;
using VitrineAPI.Domain.Pagination;

namespace VitrineAPI.Application.Interfaces
{
    public interface IProdutoApplication : IApplicationBase<Produto, ViewProdutoDto, PostProdutoDto, PutProdutoDto, PutStatusDto>
    {
        Task<ViewPagedListDto<Produto, ViewProdutoDto>> GetPaginationAsync(ParametersBase parametersBase);

        bool ValidarId(Guid id);
    }
}