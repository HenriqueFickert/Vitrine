using VitrineAPI.Application.Dtos.SubCategoria;
using VitrineAPI.Domain.Enum;

namespace VitrineAPI.Application.Dtos.Categoria
{
    /// <summary>
    /// Objeto utilizado para visualização.
    /// </summary>
    public class ViewCategoriaDto
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public Status Status { get; set; }

        public List<ViewSubCategoriaDto> SubCategorias { get; set; }
    }
}