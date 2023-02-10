using AutoMapper;
using VitrineAPI.Application.Applications.Base;
using VitrineAPI.Application.Dtos.Base;
using VitrineAPI.Application.Dtos.Pagination;
using VitrineAPI.Application.Dtos.Produto;
using VitrineAPI.Application.Dtos.Upload;
using VitrineAPI.Application.Interfaces;
using VitrineAPI.Application.Utilities.Image;
using VitrineAPI.Application.Utilities.Paths;
using VitrineAPI.Domain.Core.Interfaces.Services;
using VitrineAPI.Domain.Core.Notifier;
using VitrineAPI.Domain.Entities;
using VitrineAPI.Domain.Pagination;

namespace VitrineAPI.Application.Applications
{
    public class UploadApplication : ApplicationBase<Upload, ViewUploadDto, PostUploadDto, PutUploadDto, PutStatusDto>, IUploadApplication
    {
        private readonly IUploadService uploadService;

        public UploadApplication(IUploadService uploadService,
                                INotificador notificador,
                                IMapper mapper) : base(uploadService, notificador, mapper)
        {
            this.uploadService = uploadService;
        }

        public async Task<ViewPagedListDto<Upload, ViewUploadDto>> GetPaginationAsync(ParametersPalavraChave parametersPalavraChave)
        {
            PagedList<Upload> pagedList = await uploadService.GetPaginationAsync(parametersPalavraChave);
            return new ViewPagedListDto<Upload, ViewUploadDto>(pagedList, mapper.Map<List<ViewUploadDto>>(pagedList));
        }

        public async Task<ViewUploadDto> PostAsync(PostUploadDto postUploadDto, string caminhoFisico, string caminhoAbsoluto, string splitRelativo)
        {
            Upload objeto = mapper.Map<Upload>(postUploadDto);

            objeto.PolulateInformations(objeto, await PathCreator.CreateIpPath(caminhoFisico),
                                                await PathCreator.CreateAbsolutePath(caminhoAbsoluto),
                                                await PathCreator.CreateRelativePath(await PathCreator.CreateAbsolutePath(caminhoAbsoluto), splitRelativo));

            UploadFormMethods<Upload> uploadClass = new();
            await uploadClass.UploadImage(objeto);

            return mapper.Map<ViewUploadDto>(await uploadService.PostAsync(objeto));
        }

        public async Task<ViewUploadDto> PutAsync(PutUploadDto putUploadDto, string caminhoFisico, string caminhoAbsoluto, string splitRelativo)
        {
            Upload objeto = mapper.Map<Upload>(putUploadDto);
            Upload consulta = await uploadService.GetByIdAsync(putUploadDto.Id);

            if (consulta is null)
                return null;

            if (putUploadDto.ImagemUpload is not null)
            {
                UploadFormMethods<Upload> uploadClass = new();
                await uploadClass.DeleteImage(consulta);

                objeto.PolulateInformations(objeto, await PathCreator.CreateIpPath(caminhoFisico),
                                                    await PathCreator.CreateAbsolutePath(caminhoAbsoluto),
                                                    await PathCreator.CreateRelativePath(await PathCreator.CreateAbsolutePath(caminhoAbsoluto), splitRelativo));

                await uploadClass.UploadImage(objeto);
            }
            else
            {
                objeto.PutInformations(consulta);
            }

            return mapper.Map<ViewUploadDto>(await uploadService.PutAsync(objeto));
        }

        public bool ValidarId(Guid id)
        {
            return uploadService.ValidarId(id);
        }
    }
}