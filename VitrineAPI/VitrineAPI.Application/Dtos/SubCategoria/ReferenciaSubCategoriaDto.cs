using System.ComponentModel.DataAnnotations;

namespace VitrineAPI.Application.Dtos.SubCategoria
{
    /// <summary>
    /// Objeto utilizado para referências.
    /// </summary>
    public class ReferenciaSubCategoriaDto
    {
        /// <summary>
        /// Id da SubCategoria
        /// </summary>
        /// <example>C99EFDCD-8069-4C8B-118C-08DA91C15290</example>
        [Display(Name = "Id da subcategoria.")]
        [Required(ErrorMessage = "O campo id da subcategoria é obrigatório.")]
        [RegularExpression(@"^[{]?[0-9a-fA-F]{8}-([0-9a-fA-F]{4}-){3}[0-9a-fA-F]{12}[}]?$", ErrorMessage = "O campo id da subcategoria está em um formato inválido.")]
        public Guid Id { get; set; }
    }
}