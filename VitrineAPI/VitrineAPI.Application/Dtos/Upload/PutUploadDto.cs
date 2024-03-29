﻿using System.ComponentModel.DataAnnotations;

namespace VitrineAPI.Application.Dtos.Upload
{
    /// <summary>
    /// Objeto utilizado para atualização.
    /// </summary>
    public class PutUploadDto : PostUploadDto
    {
        /// <summary>
        /// Id da imagem
        /// </summary>
        /// <example>876777D9-EE18-4798-D3AE-08DA85F40146</example>
        [Display(Name = "Id da imagem.")]
        [Required(ErrorMessage = "O campo id da imagem é obrigatório.")]
        [RegularExpression(@"^[{]?[0-9a-fA-F]{8}-([0-9a-fA-F]{4}-){3}[0-9a-fA-F]{12}[}]?$", ErrorMessage = "O campo id da imagem está em um formato inválido.")]
        public Guid Id { get; set; }
    }
}