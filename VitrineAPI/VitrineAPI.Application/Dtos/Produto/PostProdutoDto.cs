using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using VitrineAPI.Domain.Enum;

namespace VitrineAPI.Application.Dtos.Produto
{
    /// <summary>
    /// Objeto utilizado para inserção.
    /// </summary>
    public class PostProdutoDto
    {
        [Display(Name = "Imagem do Produto.")]
        [Required(ErrorMessage = "O campo imagem do produto é obrigatório.")]
        public IFormFile ImagemUpload { get; set; }

        /// <summary>
        /// Id do Fabricante
        /// </summary>
        /// <example>5C7AC53D-0AE7-41B8-CEC9-08DA91C2F232</example>
        [Display(Name = "Id do fabricante.")]
        [Required(ErrorMessage = "O campo id do fabricante é obrigatório.")]
        [RegularExpression(@"^[{]?[0-9a-fA-F]{8}-([0-9a-fA-F]{4}-){3}[0-9a-fA-F]{12}[}]?$", ErrorMessage = "O campo id do fabricante está em um formato inválido.")]
        public Guid FabricanteId { get; set; }

        /// <summary>
        /// Id da SubCategoria
        /// </summary>
        /// <example>5C7AC53D-0AE7-41B8-CEC9-08DA91C2F232</example>
        [Display(Name = "Id da SubCategoria.")]
        [Required(ErrorMessage = "O campo id da SubCategoria é obrigatório.")]
        [RegularExpression(@"^[{]?[0-9a-fA-F]{8}-([0-9a-fA-F]{4}-){3}[0-9a-fA-F]{12}[}]?$", ErrorMessage = "O campo id da SubCategoria está em um formato inválido.")]
        public Guid SubCategoriaId { get; set; }

        /// <summary>
        /// Nome
        /// </summary>
        /// <example>Produto</example>
        [Display(Name = "Nome do produto.")]
        [Required(ErrorMessage = "O campo nome do produto é obrigatório.")]
        public string Nome { get; set; }

        /// <summary>
        /// Descrição
        /// </summary>
        /// <example>Produto</example>
        [Display(Name = "Descrição do produto.")]
        [Required(ErrorMessage = "O campo descrição do produto é obrigatório.")]
        public string Descricao { get; set; }

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
        /// Condição do Produto
        /// </summary>
        /// <example>Novo</example>
        [Display(Name = "Condição do Produto.")]
        [Required(ErrorMessage = "O campo condição do produto é obrigatório.")]
        [EnumDataType(typeof(CondicaoProduto), ErrorMessage = "O campo condição do produto é inválido.")]
        public CondicaoProduto CondicaoProduto { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        /// <example>Ativo</example>
        [Display(Name = "Status do produto.")]
        [Required(ErrorMessage = "O campo status do produto é obrigatório.")]
        [EnumDataType(typeof(Status), ErrorMessage = "O campo status é inválido.")]
        public Status Status { get; set; }
    }
}