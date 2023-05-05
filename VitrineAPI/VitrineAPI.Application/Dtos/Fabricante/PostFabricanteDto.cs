using System.ComponentModel.DataAnnotations;
using VitrineAPI.Domain.Enum;

namespace VitrineAPI.Application.Dtos.Fabricante
{
    /// <summary>
    /// Objeto utilizado para inserção.
    /// </summary>
    public class PostFabricanteDto
    {
        /// <summary>
        /// Nome
        /// </summary>
        /// <example>Gravity</example>
        [Display(Name = "Nome do Fabricante.")]
        [Required(ErrorMessage = "O campo nome do fabricante é obrigatório.")]
        public string Nome { get; set; }

        /// <summary>
        /// Descricao
        /// </summary>
        /// <example>Descrição</example>
        [Display(Name = "Descrição do fabricante.")]
        [Required(ErrorMessage = "O campo descrição do fabricante é obrigatório.")]
        public string Descricao { get; set; }

        /// <summary>
        /// CNPJ
        /// </summary>
        /// <example>94440092000174</example>
        [Display(Name = "CNPJ do fabricante.")]
        [Required(ErrorMessage = "O campo CNPJ do fabricante é obrigatório.")]
        public string CNPJ { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        /// <example>Ativo</example>
        [Display(Name = "Status do fabricante.")]
        [Required(ErrorMessage = "O campo status da fabricante é obrigatório.")]
        [EnumDataType(typeof(Status), ErrorMessage = "O campo status é inválido.")]
        public Status Status { get; set; }
    }
}