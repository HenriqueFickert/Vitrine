using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace VitrineAPI.Application.Dtos.Upload
{
    /// <summary>
    /// Objeto utilizado para inserção.
    /// </summary>
    public class PostUploadDto
    {
        [Display(Name = "Imagem.")]
        [Required(ErrorMessage = "O campo imagem é obrigatório.")]
        public IFormFile ImagemUpload { get; set; }

        /// <summary>
        /// Id do Tipo Imagem
        /// </summary>
        /// <example>5C7AC53D-0AE7-41B8-CEC9-08DA91C2F232</example>
        [Display(Name = "Id do TipoImagem.")]
        [Required(ErrorMessage = "O campo id do tipoimagem é obrigatório.")]
        [RegularExpression(@"^[{]?[0-9a-fA-F]{8}-([0-9a-fA-F]{4}-){3}[0-9a-fA-F]{12}[}]?$", ErrorMessage = "O campo id do tipoimagem está em um formato inválido.")]
        public Guid TipoImagemId { get; set; }
    }
}