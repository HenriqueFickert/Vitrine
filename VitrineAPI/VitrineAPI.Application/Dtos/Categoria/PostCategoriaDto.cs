﻿using System.ComponentModel.DataAnnotations;
using VitrineAPI.Application.Dtos.SubCategoria;
using VitrineAPI.Domain.Enum;

namespace VitrineAPI.Application.Dtos.Categoria
{
    /// <summary>
    /// Objeto utilizado para inserção.
    /// </summary>
    public class PostCategoriaDto
    {
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
        [Display(Name = "Status da cadeira.")]
        [Required(ErrorMessage = "O campo status da cadeira é obrigatório.")]
        [EnumDataType(typeof(Status), ErrorMessage = "O campo status é inválido.")]
        public Status Status { get; set; }

        /// <summary>
        /// SubCategorias
        /// </summary>
        [Display(Name = "SubCategorias da Categoria.")]
        [Required(ErrorMessage = "O campo SubCategorias da Categoria é obrigatório.")]
        public List<ReferenciaSubCategoriaDto> SubCategorias { get; set; }
    }
}