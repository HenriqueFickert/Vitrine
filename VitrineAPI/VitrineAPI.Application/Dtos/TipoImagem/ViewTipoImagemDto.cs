using VitrineAPI.Domain.Enum;

namespace VitrineAPI.Application.Dtos.TipoImagem
{
    /// <summary>
    /// Objeto utilizado para visualização.
    /// </summary>
    public class ViewTipoImagemDto
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public Status Status { get; set; }
    }
}