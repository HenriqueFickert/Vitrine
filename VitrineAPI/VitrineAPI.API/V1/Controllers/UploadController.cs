using Microsoft.AspNetCore.Mvc;
using VitrineAPI.API.Controllers;
using VitrineAPI.Application.Applications;
using VitrineAPI.Application.Dtos.Base;
using VitrineAPI.Application.Dtos.Pagination;
using VitrineAPI.Application.Dtos.Upload;
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
    [Route("/v{version:apiVersion}/Uploads")]
    [ApiController]
    public class UploadController : MainController
    {
        private readonly IUploadApplication uploadApplication;
        private readonly Ambiente ambiente;

        public UploadController(IUploadApplication uploadApplication,
                                IWebHostEnvironment environment,
                                INotificador notificador,
                                IUser user) : base(notificador, user)
        {
            this.uploadApplication = uploadApplication;

            ambiente = environment.IsProduction() ? Ambiente.Producao :
                environment.IsStaging() ? Ambiente.Homologacao : Ambiente.Desenvolvimento;
        }

        /// <summary>
        /// Retorna todos os Uploads com filtro e paginação de dados.
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(ViewPagedListDto<Upload, ViewUploadDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllAsync([FromQuery] ParametersPalavraChave parameters)
        {
            ViewPagedListDto<Upload, ViewUploadDto> result = await uploadApplication.GetPaginationAsync(parameters);

            if (result.Pagina.Count is 0)
            {
                NotificarErro("Nenhum Upload foi encontrado.");
                return CustomResponse(ModelState);
            }

            return CustomResponse(result, "Uploads encontrados.");
        }

        /// <summary>
        /// Insere um novo Upload.
        /// </summary>
        /// <param name="postUploadDto"></param>
        /// <param name="diretorios"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(ViewUploadDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostAsync([FromForm] PostUploadDto postUploadDto, Diretorios diretorios)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);


            if (!await PathSystem.ValidateURLs(diretorios.ToString(), ambiente))
            {
                NotificarErro("Diretório não encontrado.");
                return CustomResponse(ModelState);
            }

            Dictionary<string, string> Urls = await PathSystem.GetURLs(diretorios.ToString(), ambiente);

            ViewUploadDto inserido = await uploadApplication.PostAsync(postUploadDto, Urls["IP"], Urls["DNS"], Urls["SPLIT"]);

            if (inserido is null)
            {
                NotificarErro("Erro ao inserir o Upload.");
                return CustomResponse(ModelState);
            }

            return CustomResponse(inserido, "Upload criado com sucesso!");
        }

        /// <summary>
        /// Altera um Upload.
        /// </summary>
        /// <param name="putUploadDto"></param>
        /// <param name="diretorios"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(ViewUploadDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutAsync([FromForm] PutUploadDto putUploadDto, Diretorios diretorios)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            if (putUploadDto.ImagemUpload is not null)
            {
                if (!await PathSystem.ValidateURLs(diretorios.ToString(), ambiente))
                {
                    NotificarErro("Diretório não encontrado.");
                    return CustomResponse(ModelState);
                }

                Dictionary<string, string> Urls = await PathSystem.GetURLs(diretorios.ToString(), ambiente);

                ViewUploadDto atualizado = await uploadApplication.PutAsync(putUploadDto, Urls["IP"], Urls["DNS"], Urls["SPLIT"]);

                if (atualizado is null)
                {
                    NotificarErro("Nenhum evento foi encontrado com o id informado.");
                    return CustomResponse(ModelState);
                }

                return CustomResponse(atualizado, "Evento atualizado com sucesso!");
            }
            else
            {
                ViewUploadDto atualizado = await uploadApplication.PutAsync(putUploadDto, "", "", "");

                if (atualizado is null)
                {
                    NotificarErro("Nenhum evento foi encontrado com o id informado.");
                    return CustomResponse(ModelState);
                }

                return CustomResponse(atualizado, "Evento atualizado com sucesso!");
            }
        }

        /// <summary>
        /// Exclui um Upload.
        /// </summary>
        /// <param name="id"></param>
        /// <remarks>Ao excluir um Upload o mesmo será alterado para status 3 excluído.</remarks>
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(typeof(ViewUploadDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            ViewUploadDto removido = await uploadApplication.PutStatusAsync(new PutStatusDto(id, Status.Excluido));

            if (removido is null)
            {
                NotificarErro("Nenhum Upload foi encontrada com o id informado.");
                return CustomResponse(ModelState);
            }

            return CustomResponse(removido, "Upload excluída com sucesso!");
        }
    }
}