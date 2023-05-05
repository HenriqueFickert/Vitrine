using System.ComponentModel.DataAnnotations;
using VitrineAPI.Application.Dtos.SubCategoria;
using VitrineAPI.Domain.Enum;

namespace VitrineAPI.Application.Dtos.Categoria
{
    /// <summary>
    /// Objeto utilizado para atualização.
    /// </summary>
    public class PutCategoriaDto
    {
        /// <summary>
        /// Id da Categoria
        /// </summary>
        /// <example>876777D9-EE18-4798-D3AE-08DA85F40146</example>
        [Display(Name = "Id da Categoria.")]
        [Required(ErrorMessage = "O campo id da categoria é obrigatório.")]
        [RegularExpression(@"^[{]?[0-9a-fA-F]{8}-([0-9a-fA-F]{4}-){3}[0-9a-fA-F]{12}[}]?$", ErrorMessage = "O campo id da categoria está em um formato inválido.")]
        public Guid Id { get; set; }

        /// <summary>
        /// Nome
        /// </summary>
        /// <example>Categoria</example>
        [Display(Name = "Nome da categoria.")]
        [Required(ErrorMessage = "O campo nome da categoria é obrigatório.")]
        public string Nome { get; set; }

        /// <summary>
        /// Descricao
        /// </summary>
        /// <example>Descrição</example>
        [Display(Name = "Descrição da categoria.")]
        [Required(ErrorMessage = "O campo descrição da categoria é obrigatório.")]
        public string Descricao { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        /// <example>Ativo</example>
        [Display(Name = "Status da Categoria.")]
        [Required(ErrorMessage = "O campo status da categoria é obrigatório.")]
        [EnumDataType(typeof(Status), ErrorMessage = "O campo status é inválido.")]
        public Status Status { get; set; }

        /// <summary>
        /// SubCategoria
        /// </summary>
        [Display(Name = "Subcategoria")]
        public List<PutSubCategoriaDto> SubCategorias { get; set; }
    }
}