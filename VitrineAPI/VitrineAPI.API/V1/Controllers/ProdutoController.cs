using Microsoft.AspNetCore.Mvc;
using VitrineAPI.API.Controllers;
using VitrineAPI.Application.Dtos.Base;
using VitrineAPI.Application.Dtos.Pagination;
using VitrineAPI.Application.Dtos.Produto;
using VitrineAPI.Application.Interfaces;
using VitrineAPI.Application.Utilities.Paths;
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
        private readonly Ambiente ambiente;

        public ProdutoController(IProdutoApplication produtoApplication,
                                IWebHostEnvironment environment,
                                INotificador notificador,
                                IUser user) : base(notificador, user)
        {
            this.produtoApplication = produtoApplication;

            ambiente = environment.IsProduction() ? Ambiente.Producao :
                environment.IsStaging() ? Ambiente.Homologacao : Ambiente.Desenvolvimento;
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
        /// <param name="diretorios"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(ViewProdutoDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostAsync([FromForm] PostProdutoDto postProdutoDto, Diretorios diretorios)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            if (!await PathSystem.ValidateURLs(diretorios.ToString(), ambiente))
            {
                NotificarErro("Diretório não encontrado.");
                return CustomResponse(ModelState);
            }

            Dictionary<string, string> Urls = await PathSystem.GetURLs(diretorios.ToString(), ambiente);

            ViewProdutoDto inserido = await produtoApplication.PostAsync(postProdutoDto, Urls["IP"], Urls["DNS"], Urls["SPLIT"]);

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
        /// <param name="diretorios"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(ViewProdutoDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutAsync([FromForm] PutProdutoDto putProdutoDto, Diretorios diretorios)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            if (putProdutoDto.ImagemUpload is not null)
            {
                if (!await PathSystem.ValidateURLs(diretorios.ToString(), ambiente))
                {
                    NotificarErro("Diretório não encontrado.");
                    return CustomResponse(ModelState);
                }

                Dictionary<string, string> Urls = await PathSystem.GetURLs(diretorios.ToString(), ambiente);

                ViewProdutoDto atualizado = await produtoApplication.PutAsync(putProdutoDto, Urls["IP"], Urls["DNS"], Urls["SPLIT"]);

                if (atualizado is null)
                {
                    NotificarErro("Nenhum evento foi encontrado com o id informado.");
                    return CustomResponse(ModelState);
                }

                return CustomResponse(atualizado, "Evento atualizado com sucesso!");
            }
            else
            {
                ViewProdutoDto atualizado = await produtoApplication.PutAsync(putProdutoDto, "", "", "");

                if (atualizado is null)
                {
                    NotificarErro("Nenhum evento foi encontrado com o id informado.");
                    return CustomResponse(ModelState);
                }

                return CustomResponse(atualizado, "Evento atualizado com sucesso!");
            }
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