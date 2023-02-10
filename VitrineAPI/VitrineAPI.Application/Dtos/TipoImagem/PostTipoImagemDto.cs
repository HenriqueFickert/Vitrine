using System.ComponentModel.DataAnnotations;

namespace VitrineAPI.Application.Dtos.TipoImagem
{
    /// <summary>
    /// Objeto utilizado para inserção.
    /// </summary>
    public class PostTipoImagemDto
    {
        /// <summary>
        /// Nome
        /// </summary>
        /// <example>Produto</example>
        [Display(Name = "Nome do TipoImagem.")]
        [Required(ErrorMessage = "O campo nome do tipoimagem é obrigatório.")]
        public string Nome { get; set; }
    }
}