using VitrineAPI.Application.Dtos.Identity.Autenticacao;
using VitrineAPI.Application.Dtos.Identity.Autenticacao.InternalResponses;
using VitrineAPI.Application.Dtos.Identity.Usuario;
using VitrineAPI.Domain.Pagination;

namespace VitrineAPI.Application.Interfaces
{
    public interface IUsuarioApplication
    {
        Task<ViewPaginacaoUsuarioDto> GetPaginationAsync(ParametersPalavraChave parametersPalavraChave);

        Task<ViewUsuarioDto> GetByIdAsync(Guid id);

        Task<DefaultResponse> CadastrarUsuario(PostCadastroUsuarioDto postCadastroUsuarioDto);

        Task<UsuarioLoginResponse> Login(PostLoginUsuarioDto postLoginUsuarioDto);

        Task<DefaultResponse> AlterarSenha(PostAlterarSenhaUsuarioDto postAlterarSenhaUsuarioDto);

        Task<DefaultResponse> ResetarSenha(PostResetarSenhaDto postResetarSenhaDto);

        Task<DefaultResponse> EnviarEmailResetarSenha(PostEmailDto postConfirmacaoEmailDto);

        Task<DefaultResponse> ConfimarEmail(PostConfirmacaoEmailDto postConfirmacaoEmailDto);

        Task<DefaultResponse> ReenviarConfirmacaoEmail(PostEmailDto postConfirmacaoEmailDto);

        Task<ViewUsuarioDto> DeleteAsync(Guid id);

        bool ValidarId(Guid id);
    }
}