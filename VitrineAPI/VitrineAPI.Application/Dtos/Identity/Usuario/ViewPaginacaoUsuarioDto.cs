using VitrineAPI.Application.Dtos.Pagination;

namespace VitrineAPI.Application.Dtos.Identity.Usuario
{
    /// <summary>
    /// Objeto utilizado para visualização páginada de usuário.
    /// </summary>
    public class ViewPaginacaoUsuarioDto
    {
        public ICollection<ViewUsuarioDto> Usuarios { get; set; }

        public ViewPaginationDataDto<VitrineAPI.Identity.Entities.Usuario> DadosPaginacao { get; set; }

        public ViewPaginacaoUsuarioDto()
        {
            Usuarios = new List<ViewUsuarioDto>();
            DadosPaginacao = new ViewPaginationDataDto<VitrineAPI.Identity.Entities.Usuario>();
        }
    }
}