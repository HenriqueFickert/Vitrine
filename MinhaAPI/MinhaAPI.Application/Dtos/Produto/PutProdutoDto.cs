﻿using System.ComponentModel.DataAnnotations;

namespace MinhaAPI.Application.Dtos.Produto
{
    /// <summary>
    /// Objeto utilizado para atualização.
    /// </summary>
    public class PutProdutoDto : PostProdutoDto
    {
        /// <summary>
        /// Id da Cadeira
        /// </summary>
        /// <example>876777D9-EE18-4798-D3AE-08DA85F40146</example>
        [Display(Name = "Id do produto.")]
        [Required(ErrorMessage = "O campo id do produto é obrigatório.")]
        [RegularExpression(@"^[{]?[0-9a-fA-F]{8}-([0-9a-fA-F]{4}-){3}[0-9a-fA-F]{12}[}]?$", ErrorMessage = "O campo id do produto está em um formato inválido.")]
        public Guid Id { get; set; }
    }
}