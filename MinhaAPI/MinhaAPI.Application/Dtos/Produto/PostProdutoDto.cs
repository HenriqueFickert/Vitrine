using MinhaAPI.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace MinhaAPI.Application.Dtos.Produto
{
    /// <summary>
    /// Objeto utilizado para inserção.
    /// </summary>
    public class PostProdutoDto
    {
        /// <summary>
        /// Nome
        /// </summary>
        /// <example>Cadeira</example>
        [Display(Name = "Nome do produto.")]
        public string Nome { get; set; }

        /// <summary>
        /// Valor
        /// </summary>
        /// <example>1</example>
        [Display(Name = "Valor do produto.")]
        [Required(ErrorMessage = "O campo valor do produto é obrigatório.")]
        public int Valor { get; set; }

        /// <summary>
        /// Quantidade
        /// </summary>
        /// <example>1</example>
        [Display(Name = "Quantidade do produto.")]
        [Required(ErrorMessage = "O campo quantidade do produto é obrigatório.")]
        public int Quantidade { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        /// <example>Ativo</example>
        [Display(Name = "Status da cadeira.")]
        [Required(ErrorMessage = "O campo status da cadeira é obrigatório.")]
        [EnumDataType(typeof(Status), ErrorMessage = "O campo status é inválido.")]
        public Status Status { get; set; }
    }
}