using System.ComponentModel.DataAnnotations;

namespace VitrineAPI.Application.Dtos.SubCategoria
{
    /// <summary>
    /// Objeto utilizado para atualização.
    /// </summary>
    public class PutSubCategoriaDto : PostSubCategoriaDto
    {
        /// <summary>
        /// Id da SubCategoria
        /// </summary>
        /// <example>876777D9-EE18-4798-D3AE-08DA85F40146</example>
        [Display(Name = "Id da SubCategoria.")]
        [Required(ErrorMessage = "O campo id da subcategoria é obrigatório.")]
        [RegularExpression(@"^[{]?[0-9a-fA-F]{8}-([0-9a-fA-F]{4}-){3}[0-9a-fA-F]{12}[}]?$", ErrorMessage = "O campo id da subcategoria está em um formato inválido.")]
        public Guid Id { get; set; }
    }
}