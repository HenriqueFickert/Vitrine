using MinhaAPI.Domain.Entities.Base;
using MinhaAPI.Domain.Pagination;

namespace MinhaAPI.Application.Dtos.Pagination
{
    /// <summary>
    /// Objeto utilizado para visualização páginada.
    /// </summary>
    public class ViewPagedListDto<TEntity, TView> where TEntity : EntityBase where TView : class
    {
        public ICollection<TView> Pagina { get; set; }

        public ViewPaginationDataDto<TEntity> Dados { get; set; }

        public ViewPagedListDto(PagedList<TEntity> pagedList, List<TView> list)
        {
            Pagina = list;
            Dados = new ViewPaginationDataDto<TEntity>(pagedList);
        }
    }
}