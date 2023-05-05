namespace VitrineAPI.Application.Dtos.Identity.Autenticacao.InternalResponses
{
    public class UsuarioLoginResponse : DefaultResponse
    {
        public string AccessToken { get; private set; }
        public string RefreshToken { get; private set; }
        public string NomeUsuario { get; private set; }

        public UsuarioLoginResponse()
        { }

        public UsuarioLoginResponse(string accessToken, string refreshToken, string nomeUsuario) : this()
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
            NomeUsuario = nomeUsuario;
        }
    }
}