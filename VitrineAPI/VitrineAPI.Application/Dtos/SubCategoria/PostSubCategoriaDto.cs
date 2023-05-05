using System.ComponentModel.DataAnnotations;
using VitrineAPI.Domain.Enum;

namespace VitrineAPI.Application.Dtos.SubCategoria
{
    /// <summary>
    /// Objeto utilizado para inserção.
    /// </summary>
    public class PostSubCategoriaDto
    {
        /// <summary>
        /// Nome
        /// </summary>
        /// <example>SubCategoria</example>
        [Display(Name = "Nome da subcategoria.")]
        [Required(ErrorMessage = "O campo nome da subcategoria é obrigatório.")]
        public string Nome { get; set; }

        /// <summary>
        /// Descricao
        /// </summary>
        /// <example>Descrição</example>
        [Display(Name = "Descrição da subcategoria.")]
        [Required(ErrorMessage = "O campo descrição da subcategoria é obrigatório.")]
        public string Descricao { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        /// <example>Ativo</example>
        [Display(Name = "Status da SubCategoria.")]
        [Required(ErrorMessage = "O campo status da subcategoria é obrigatório.")]
        [EnumDataType(typeof(Status), ErrorMessage = "O campo status é inválido.")]
        public Status Status { get; set; }
    }
}