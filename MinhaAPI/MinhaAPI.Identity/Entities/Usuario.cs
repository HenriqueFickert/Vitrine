using Microsoft.AspNetCore.Identity;

namespace MinhaAPI.Identity.Entities
{
    public class Usuario : IdentityUser
    {
        public string Nome { get; set; }

        public string CPF { get; set; }

        public DateTime Nascimento { get; set; }

        public string Genero { get; set; }

        public string Status { get; set; }

        public DateTimeOffset? UltimoAcesso { get; set; }

        public DateTime CriadoEm { get; set; }

        public DateTime? AlteradoEm { get; set; }

        public void AlteraUltimoAcesso()
        {
            UltimoAcesso = DateTimeOffset.Now;
        }
    }
}