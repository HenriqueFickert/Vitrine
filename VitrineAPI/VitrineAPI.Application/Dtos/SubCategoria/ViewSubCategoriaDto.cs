using VitrineAPI.Domain.Enum;

namespace VitrineAPI.Application.Dtos.SubCategoria
{
    /// <summary>
    /// Objeto utilizado para visualização.
    /// </summary>
    public class ViewSubCategoriaDto
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public Status Status { get; set; }
    }
}