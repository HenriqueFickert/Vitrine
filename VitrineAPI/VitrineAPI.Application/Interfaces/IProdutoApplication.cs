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

        Task<ViewProdutoDto> PostAsync(PostProdutoDto postProdutoDto, string caminhoFisico, string caminhoAbsoluto, string splitRelativo);

        Task<ViewProdutoDto> PutAsync(PutProdutoDto putProdutoDto, string caminhoFisico, string caminhoAbsoluto, string splitRelativo);

        bool ValidarId(Guid id);
    }
}