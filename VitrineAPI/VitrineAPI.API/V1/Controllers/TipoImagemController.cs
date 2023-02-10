using Microsoft.AspNetCore.Mvc;
using VitrineAPI.API.Controllers;
using VitrineAPI.Application.Dtos.Base;
using VitrineAPI.Application.Dtos.TipoImagem;
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
    [Route("/v{version:apiVersion}/TipoImagens")]
    [ApiController]
    public class TipoImagemController : MainController
    {
        private readonly ITipoImagemApplication tipoImagemApplication;

        public TipoImagemController(ITipoImagemApplication tipoImagemApplication,
                                 INotificador notificador,
                                 IUser user) : base(notificador, user)
        {
            this.tipoImagemApplication = tipoImagemApplication;
        }

        /// <summary>
        /// Retorna todas as TipoImagens com filtro e paginação de dados.
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(ViewPagedListDto<TipoImagem, ViewTipoImagemDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllAsync([FromQuery] ParametersPalavraChave parameters)
        {
            ViewPagedListDto<TipoImagem, ViewTipoImagemDto> result = await tipoImagemApplication.GetPaginationAsync(parameters);

            if (result.Pagina.Count is 0)
            {
                NotificarErro("Nenhum TipoImagem foi encontrado.");
                return CustomResponse(ModelState);
            }

            return CustomResponse(result, "TipoImagens encontrados.");
        }

        /// <summary>
        /// Insere uma nova TipoImagem.
        /// </summary>
        /// <param name="postTipoImagemDto"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(ViewTipoImagemDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostAsync([FromBody] PostTipoImagemDto postTipoImagemDto)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            ViewTipoImagemDto inserido = await tipoImagemApplication.PostAsync(postTipoImagemDto);

            if (inserido is null)
            {
                NotificarErro("Erro ao inserir o TipoImagem.");
                return CustomResponse(ModelState);
            }

            return CustomResponse(inserido, "TipoImagem criado com sucesso!");
        }

        /// <summary>
        /// Altera uma TipoImagem.
        /// </summary>
        /// <param name="putTipoImagemDto"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(ViewTipoImagemDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutAsync([FromBody] PutTipoImagemDto putTipoImagemDto)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            ViewTipoImagemDto atualizado = await tipoImagemApplication.PutAsync(putTipoImagemDto);

            if (atualizado is null)
            {
                NotificarErro("Nenhum TipoImagem foi encontrado com o id informado.");
                return CustomResponse(ModelState);
            }

            return CustomResponse(atualizado, "TipoImagem atualizado com sucesso!");
        }

        /// <summary>
        /// Exclui uma TipoImagem.
        /// </summary>
        /// <param name="id"></param>
        /// <remarks>Ao excluir um TipoImagem o mesmo será alterado para status 3 excluído.</remarks>
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(typeof(ViewTipoImagemDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            ViewTipoImagemDto removido = await tipoImagemApplication.PutStatusAsync(new PutStatusDto(id, Status.Excluido));

            if (removido is null)
            {
                NotificarErro("Nenhuma TipoImagem foi encontrado com o id informado.");
                return CustomResponse(ModelState);
            }

            return CustomResponse(removido, "TipoImagem excluído com sucesso!");
        }
    }
}
