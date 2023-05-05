using VitrineAPI.Application.Dtos.Identity.Autenticacao.InternalResponses;

namespace VitrineAPI.Application.Dtos.Identity.Autenticacao
{
    /// <summary>
    /// Objeto utilizado para visualização dos dados de login.
    /// </summary>
    public class ViewLoginDto
    {
        public string AccessToken { get; private set; }

        public string RefreshToken { get; private set; }

        public string NomeUsuario { get; private set; }

        public ViewLoginDto(UsuarioLoginResponse reponseTokenDto)
        {
            AccessToken = reponseTokenDto.AccessToken;
            RefreshToken = reponseTokenDto.RefreshToken;
            NomeUsuario = reponseTokenDto.NomeUsuario;
        }
    }
}