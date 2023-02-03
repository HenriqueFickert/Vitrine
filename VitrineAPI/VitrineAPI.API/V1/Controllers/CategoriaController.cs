using Microsoft.AspNetCore.Mvc;
using VitrineAPI.API.Controllers;
using VitrineAPI.Application.Dtos.Base;
using VitrineAPI.Application.Dtos.Categoria;
using VitrineAPI.Application.Dtos.Pagination;
using VitrineAPI.Application.Interfaces;
using VitrineAPI.Domain.Core.Interfaces.Services;
using VitrineAPI.Domain.Core.Notifier;
using VitrineAPI.Domain.Entities;
using VitrineAPI.Domain.Enum;
using VitrineAPI.Domain.Pagination;

namespace VitrineAPI.API.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("/v{version:apiVersion}/categorias")]
    [ApiController]
    public class CategoriaController : MainController
    {
        private readonly ICategoriaApplication categoriasApplication;

        public CategoriaController(ICategoriaApplication categoriasApplication,
                                 INotificador notificador,
                                 IUser user) : base(notificador, user)
        {
            this.categoriasApplication = categoriasApplication;
        }

        /// <summary>
        /// Retorna todas as categorias com filtro e paginação de dados.
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(ViewPagedListDto<Categoria, ViewCategoriaDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllAsync([FromQuery] ParametersPalavraChave parameters)
        {
            ViewPagedListDto<Categoria, ViewCategoriaDto> result = await categoriasApplication.GetPaginationAsync(parameters);

            if (result.Pagina.Count is 0)
            {
                NotificarErro("Nenhuma categoria foi encontrada.");
                return CustomResponse(ModelState);
            }

            return CustomResponse(result, "Categorias encontradas.");
        }

        /// <summary>
        /// Insere uma nova categoria.
        /// </summary>
        /// <param name="postCategoriaDto"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(ViewCategoriaDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostAsync([FromBody] PostCategoriaDto postCategoriaDto)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            ViewCategoriaDto inserido = await categoriasApplication.PostAsync(postCategoriaDto);

            if (inserido is null)
            {
                NotificarErro("Erro ao inserir a categoria.");
                return CustomResponse(ModelState);
            }

            return CustomResponse(inserido, "Categoria criada com sucesso!");
        }

        /// <summary>
        /// Altera uma categoria.
        /// </summary>
        /// <param name="putCategoriaDto"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(ViewCategoriaDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutAsync([FromBody] PutCategoriaDto putCategoriaDto)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            ViewCategoriaDto atualizado = await categoriasApplication.PutAsync(putCategoriaDto);

            if (atualizado is null)
            {
                NotificarErro("Nenhuma categoria foi encontrada com o id informado.");
                return CustomResponse(ModelState);
            }

            return CustomResponse(atualizado, "Categoria atualizada com sucesso!");
        }

        /// <summary>
        /// Exclui uma Categoria.
        /// </summary>
        /// <param name="id"></param>
        /// <remarks>Ao excluir uma categoria o mesmo será alterado para status 3 excluído.</remarks>
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(typeof(ViewCategoriaDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            ViewCategoriaDto removido = await categoriasApplication.PutStatusAsync(new PutStatusDto(id, Status.Excluido));

            if (removido is null)
            {
                NotificarErro("Nenhuma categoria foi encontrada com o id informado.");
                return CustomResponse(ModelState);
            }

            return CustomResponse(removido, "Categoria excluída com sucesso!");
        }
    }
}