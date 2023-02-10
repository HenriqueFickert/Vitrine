using Microsoft.AspNetCore.Mvc;
using VitrineAPI.API.Controllers;
using VitrineAPI.Application.Dtos.Base;
using VitrineAPI.Application.Dtos.Fabricante;
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
    [Route("/v{version:apiVersion}/fabricantes")]
    [ApiController]
    public class FabricanteController : MainController
    {
        private readonly IFabricanteApplication fabricanteApplication;

        public FabricanteController(IFabricanteApplication fabricanteApplication,
                                 INotificador notificador,
                                 IUser user) : base(notificador, user)
        {
            this.fabricanteApplication = fabricanteApplication;
        }

        /// <summary>
        /// Retorna todas as Fabricantes com filtro e paginação de dados.
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(ViewPagedListDto<Fabricante, ViewFabricanteDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllAsync([FromQuery] ParametersPalavraChave parameters)
        {
            ViewPagedListDto<Fabricante, ViewFabricanteDto> result = await fabricanteApplication.GetPaginationAsync(parameters);

            if (result.Pagina.Count is 0)
            {
                NotificarErro("Nenhum fabricante foi encontrado.");
                return CustomResponse(ModelState);
            }

            return CustomResponse(result, "Fabricantes encontrados.");
        }

        /// <summary>
        /// Insere uma nova Fabricante.
        /// </summary>
        /// <param name="postFabricanteDto"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(ViewFabricanteDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostAsync([FromBody] PostFabricanteDto postFabricanteDto)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            ViewFabricanteDto inserido = await fabricanteApplication.PostAsync(postFabricanteDto);

            if (inserido is null)
            {
                NotificarErro("Erro ao inserir o fabricante.");
                return CustomResponse(ModelState);
            }

            return CustomResponse(inserido, "Fabricante criado com sucesso!");
        }

        /// <summary>
        /// Altera uma Fabricante.
        /// </summary>
        /// <param name="putFabricanteDto"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(ViewFabricanteDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutAsync([FromBody] PutFabricanteDto putFabricanteDto)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            ViewFabricanteDto atualizado = await fabricanteApplication.PutAsync(putFabricanteDto);

            if (atualizado is null)
            {
                NotificarErro("Nenhum fabricante foi encontrado com o id informado.");
                return CustomResponse(ModelState);
            }

            return CustomResponse(atualizado, "Fabricante atualizado com sucesso!");
        }

        /// <summary>
        /// Exclui uma fabricante.
        /// </summary>
        /// <param name="id"></param>
        /// <remarks>Ao excluir um fabricante o mesmo será alterado para status 3 excluído.</remarks>
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(typeof(ViewFabricanteDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            ViewFabricanteDto removido = await fabricanteApplication.PutStatusAsync(new PutStatusDto(id, Status.Excluido));

            if (removido is null)
            {
                NotificarErro("Nenhuma fabricante foi encontrado com o id informado.");
                return CustomResponse(ModelState);
            }

            return CustomResponse(removido, "Fabricante excluído com sucesso!");
        }
    }
}