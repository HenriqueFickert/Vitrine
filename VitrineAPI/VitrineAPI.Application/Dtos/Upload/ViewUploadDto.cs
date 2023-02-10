using VitrineAPI.Application.Dtos.TipoImagem;
using VitrineAPI.Domain.Enum;

namespace VitrineAPI.Application.Dtos.Upload
{
    /// <summary>
    /// Objeto utilizado para visualização.
    /// </summary>
    public class ViewUploadDto
    {
        public Guid Id { get; set; }

        public string CaminhoAbsoluto { get; set; }

        public string CaminhoRelativo { get; set; }

        public ViewTipoImagemDto TipoImagem { get; set; }

        public Status Status { get; set; }
    }
}