using VitrineAPI.Domain.Enum;

namespace VitrineAPI.Application.Dtos.Identity.Usuario
{
    /// <summary>
    /// Objeto utilizado para visualização.
    /// </summary>
    public class ViewUsuarioDto
    {
        public Guid Id { get; set; }

        public string Email { get; set; }

        public string Nome { get; set; }

        public string CPF { get; set; }

        public DateTime Nascimento { get; set; }

        public Genero Genero { get; set; }

        public Status Status { get; set; }

        public ViewUsuarioDto()
        {
        }

        public ViewUsuarioDto(VitrineAPI.Identity.Entities.Usuario usuario)
        {
            Id = Guid.Parse(usuario.Id);
            Nome = usuario.Nome;
            Email = usuario.Email;
            CPF = usuario.CPF;
            Nascimento = usuario.Nascimento;
            _ = Enum.TryParse(usuario.Genero, out Genero myGender);
            Genero = myGender;
            _ = Enum.TryParse(usuario.Status, out Status myStatus);
            Status = myStatus;
        }
    }
}