using VitrineAPI.Domain.Enum;

namespace VitrineAPI.Application.Dtos.Produto
{
    /// <summary>
    /// Objeto utilizado para visualização.
    /// </summary>
    public class ViewProdutoDto
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public int Valor { get; set; }

        public int Quantidade { get; set; }

        public Status Status { get; set; }
    }
}