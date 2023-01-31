using Microsoft.AspNetCore.Mvc;
using VitrineAPI.API.Controllers;
using VitrineAPI.Application.Dtos.Base;
using VitrineAPI.Application.Dtos.Pagination;
using VitrineAPI.Application.Dtos.Produto;
using VitrineAPI.Application.Interfaces;
using VitrineAPI.Domain.Core.Interfaces.Services;
using VitrineAPI.Domain.Core.Notifier;
using VitrineAPI.Domain.Entities;
using VitrineAPI.Domain.Enum;
using VitrineAPI.Domain.Pagination;

namespace VitrineAPI.API.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("/v{version:apiVersion}/produtos")]
    [ApiController]
    public class ProdutoController : MainController
    {
        private readonly IProdutoApplication produtoApplication;

        public ProdutoController(IProdutoApplication produtoApplication,
                                INotificador notificador,
                                IUser user) : base(notificador, user)
        {
            this.produtoApplication = produtoApplication;
        }

        /// <summary>
        /// Retorna todos os produtos com filtro e paginação de dados.
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(ViewPagedListDto<Produto, ViewProdutoDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllAsync([FromQuery] ParametersBase parameters)
        {
            ViewPagedListDto<Produto, ViewProdutoDto> result = await produtoApplication.GetPaginationAsync(parameters);

            if (result.Pagina.Count is 0)
            {
                NotificarErro("Nenhum produto foi encontrado.");
                return CustomResponse(ModelState);
            }

            return CustomResponse(result, "Produtos encontrados.");
        }

        /// <summary>
        /// Insere um novo produto.
        /// </summary>
        /// <param name="postProdutoDto"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(ViewProdutoDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostAsync([FromBody] PostProdutoDto postProdutoDto)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            ViewProdutoDto inserido = await produtoApplication.PostAsync(postProdutoDto);

            if (inserido is null)
            {
                NotificarErro("Erro ao inserir o produto.");
                return CustomResponse(ModelState);
            }

            return CustomResponse(inserido, "Produto criado com sucesso!");
        }

        /// <summary>
        /// Altera um produto.
        /// </summary>
        /// <param name="putProdutoDto"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(ViewProdutoDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutAsync([FromBody] PutProdutoDto putProdutoDto)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            ViewProdutoDto atualizado = await produtoApplication.PutAsync(putProdutoDto);

            if (atualizado is null)
            {
                NotificarErro("Nenhum produto foi encontrado com o id informado.");
                return CustomResponse(ModelState);
            }

            return CustomResponse(atualizado, "Produto atualizado com sucesso!");
        }

        /// <summary>
        /// Exclui um produto.
        /// </summary>
        /// <param name="id"></param>
        /// <remarks>Ao excluir um produto o mesmo será alterado para status 3 excluído.</remarks>
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(typeof(ViewProdutoDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            ViewProdutoDto removido = await produtoApplication.PutStatusAsync(new PutStatusDto(id, Status.Excluido));

            if (removido is null)
            {
                NotificarErro("Nenhum produto foi encontrada com o id informado.");
                return CustomResponse(ModelState);
            }

            return CustomResponse(removido, "Produto excluída com sucesso!");
        }
    }
}