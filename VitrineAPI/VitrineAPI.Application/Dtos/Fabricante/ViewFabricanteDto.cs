using VitrineAPI.Domain.Enum;

namespace VitrineAPI.Application.Dtos.Fabricante
{
    /// <summary>
    /// Objeto utilizado para visualização.
    /// </summary>
    public class ViewFabricanteDto
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public string CNPJ { get; set; }

        public Status Status { get; set; }
    }
}