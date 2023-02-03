using System.ComponentModel.DataAnnotations;

namespace VitrineAPI.Application.Dtos.Categoria
{
    /// <summary>
    /// Objeto utilizado para atualização.
    /// </summary>
    public class PutCategoriaDto : PostCategoriaDto
    {
        /// <summary>
        /// Id da Categoria
        /// </summary>
        /// <example>876777D9-EE18-4798-D3AE-08DA85F40146</example>
        [Display(Name = "Id da Categoria.")]
        [Required(ErrorMessage = "O campo id da categoria é obrigatório.")]
        [RegularExpression(@"^[{]?[0-9a-fA-F]{8}-([0-9a-fA-F]{4}-){3}[0-9a-fA-F]{12}[}]?$", ErrorMessage = "O campo id da categoria está em um formato inválido.")]
        public Guid Id { get; set; }
    }
}