using AutoMapper;
using VitrineAPI.Application.Applications.Base;
using VitrineAPI.Application.Dtos.Base;
using VitrineAPI.Application.Dtos.Pagination;
using VitrineAPI.Application.Dtos.Produto;
using VitrineAPI.Application.Interfaces;
using VitrineAPI.Application.Utilities.Image;
using VitrineAPI.Application.Utilities.Paths;
using VitrineAPI.Domain.Core.Interfaces.Services;
using VitrineAPI.Domain.Core.Notifier;
using VitrineAPI.Domain.Entities;
using VitrineAPI.Domain.Pagination;

namespace VitrineAPI.Application.Applications
{
    public class ProdutoApplication : ApplicationBase<Produto, ViewProdutoDto, PostProdutoDto, PutProdutoDto, PutStatusDto>, IProdutoApplication
    {
        private readonly IProdutoService produtoService;

        public ProdutoApplication(IProdutoService produtoService,
                                INotificador notificador,
                                IMapper mapper) : base(produtoService, notificador, mapper)
        {
            this.produtoService = produtoService;
        }

        public async Task<ViewPagedListDto<Produto, ViewProdutoDto>> GetPaginationAsync(ParametersBase parametersBase)
        {
            PagedList<Produto> pagedList = await produtoService.GetPaginationAsync(parametersBase);
            return new ViewPagedListDto<Produto, ViewProdutoDto>(pagedList, mapper.Map<List<ViewProdutoDto>>(pagedList));
        }

        public async Task<ViewProdutoDto> PostAsync(PostProdutoDto postProdutoDto, string caminhoFisico, string caminhoAbsoluto, string splitRelativo)
        {
            Produto objeto = mapper.Map<Produto>(postProdutoDto);

            objeto.PolulateInformations(objeto, await PathCreator.CreateIpPath(caminhoFisico),
                                                await PathCreator.CreateAbsolutePath(caminhoAbsoluto),
                                                await PathCreator.CreateRelativePath(await PathCreator.CreateAbsolutePath(caminhoAbsoluto), splitRelativo));

            UploadFormMethods<Produto> uploadClass = new();
            await uploadClass.UploadImage(objeto);

            return mapper.Map<ViewProdutoDto>(await produtoService.PostAsync(objeto));
        }

        public async Task<ViewProdutoDto> PutAsync(PutProdutoDto putProdutoDto, string caminhoFisico, string caminhoAbsoluto, string splitRelativo)
        {
            Produto objeto = mapper.Map<Produto>(putProdutoDto);
            Produto consulta = await produtoService.GetByIdAsync(putProdutoDto.Id);

            if (consulta is null)
                return null;

            if (putProdutoDto.ImagemUpload is not null)
            {
                UploadFormMethods<Produto> uploadClass = new();
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

            return mapper.Map<ViewProdutoDto>(await produtoService.PutAsync(objeto));
        }

        public bool ValidarId(Guid id)
        {
            return produtoService.ValidarId(id);
        }
    }
}