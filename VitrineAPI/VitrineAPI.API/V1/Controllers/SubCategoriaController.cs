using Microsoft.AspNetCore.Mvc;
using VitrineAPI.API.Controllers;
using VitrineAPI.Application.Dtos.Base;
using VitrineAPI.Application.Dtos.Pagination;
using VitrineAPI.Application.Dtos.SubCategoria;
using VitrineAPI.Application.Interfaces;
using VitrineAPI.Domain.Core.Interfaces.Services;
using VitrineAPI.Domain.Core.Notifier;
using VitrineAPI.Domain.Entities;
using VitrineAPI.Domain.Enum;
using VitrineAPI.Domain.Pagination;

namespace VitrineAPI.API.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("/v{version:apiVersion}/subcategorias")]
    [ApiController]
    public class SubCategoriaController : MainController
    {
        private readonly ISubCategoriaApplication subCategoriaApplication;

        public SubCategoriaController(ISubCategoriaApplication subCategoriaApplication,
                                 INotificador notificador,
                                 IUser user) : base(notificador, user)
        {
            this.subCategoriaApplication = subCategoriaApplication;
        }

        /// <summary>
        /// Retorna todas as subcategorias com filtro e paginação de dados.
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(ViewPagedListDto<SubCategoria, ViewSubCategoriaDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllAsync([FromQuery] ParametersPalavraChave parameters)
        {
            ViewPagedListDto<SubCategoria, ViewSubCategoriaDto> result = await subCategoriaApplication.GetPaginationAsync(parameters);

            if (result.Pagina.Count is 0)
            {
                NotificarErro("Nenhuma subcategoria foi encontrada.");
                return CustomResponse(ModelState);
            }

            return CustomResponse(result, "Subcategorias encontradas.");
        }

        /// <summary>
        /// Insere uma nova subcategoria.
        /// </summary>
        /// <param name="postSubCategoriaDto"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(ViewSubCategoriaDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostAsync([FromBody] PostSubCategoriaDto postSubCategoriaDto)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            ViewSubCategoriaDto inserido = await subCategoriaApplication.PostAsync(postSubCategoriaDto);

            if (inserido is null)
            {
                NotificarErro("Erro ao inserir a subcategoria.");
                return CustomResponse(ModelState);
            }

            return CustomResponse(inserido, "Subcategoria criada com sucesso!");
        }

        /// <summary>
        /// Altera uma subcategoria.
        /// </summary>
        /// <param name="putSubCategoriaDto"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(ViewSubCategoriaDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutAsync([FromBody] PutSubCategoriaDto putSubCategoriaDto)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            ViewSubCategoriaDto atualizado = await subCategoriaApplication.PutAsync(putSubCategoriaDto);

            if (atualizado is null)
            {
                NotificarErro("Nenhuma subcategoria foi encontrada com o id informado.");
                return CustomResponse(ModelState);
            }

            return CustomResponse(atualizado, "Subcategoria atualizada com sucesso!");
        }

        /// <summary>
        /// Exclui uma subcategoria.
        /// </summary>
        /// <param name="id"></param>
        /// <remarks>Ao excluir uma subcategoria o mesmo será alterado para status 3 excluído.</remarks>
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(typeof(ViewSubCategoriaDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            ViewSubCategoriaDto removido = await subCategoriaApplication.PutStatusAsync(new PutStatusDto(id, Status.Excluido));

            if (removido is null)
            {
                NotificarErro("Nenhuma subcategoria foi encontrada com o id informado.");
                return CustomResponse(ModelState);
            }

            return CustomResponse(removido, "Subcategoria excluída com sucesso!");
        }
    }
}