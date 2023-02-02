namespace VitrineAPI.Application.Dtos.Identity.Autenticacao.InternalResponses
{
    public class DefaultResponse
    {
        public bool Sucesso => Erros.Count == 0;

        public List<string> Erros { get; private set; }

        public DefaultResponse() =>
            Erros = new List<string>();

        public DefaultResponse(bool sucesso = true) : this()
        {
        }

        public void AdicionarErro(string erro) =>
            Erros.Add(erro);

        public void AdicionarErros(IEnumerable<string> erros) =>
            Erros.AddRange(erros);
    }
}