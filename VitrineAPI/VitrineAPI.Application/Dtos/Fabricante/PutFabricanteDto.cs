using System.ComponentModel.DataAnnotations;

namespace VitrineAPI.Application.Dtos.Fabricante
{
    /// <summary>
    /// Objeto utilizado para atualização.
    /// </summary>
    public class PutFabricanteDto : PostFabricanteDto
    {
        /// <summary>
        /// Id da Fabricante
        /// </summary>
        /// <example>876777D9-EE18-4798-D3AE-08DA85F40146</example>
        [Display(Name = "Id do fabricante.")]
        [Required(ErrorMessage = "O campo id do fabricante é obrigatório.")]
        [RegularExpression(@"^[{]?[0-9a-fA-F]{8}-([0-9a-fA-F]{4}-){3}[0-9a-fA-F]{12}[}]?$", ErrorMessage = "O campo id do fabricante está em um formato inválido.")]
        public Guid Id { get; set; }
    }
}