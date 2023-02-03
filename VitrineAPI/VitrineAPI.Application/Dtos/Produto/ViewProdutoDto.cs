using VitrineAPI.Application.Dtos.Fabricante;
using VitrineAPI.Application.Dtos.SubCategoria;
using VitrineAPI.Domain.Enum;

namespace VitrineAPI.Application.Dtos.Produto
{
    /// <summary>
    /// Objeto utilizado para visualização.
    /// </summary>
    public class ViewProdutoDto
    {
        public Guid Id { get; set; }

        public Guid FabricanteId { get; set; }

        public Guid SubCategoriaId { get; set; }

        public string Nome { get; set; }

        public int Valor { get; set; }

        public int Quantidade { get; set; }

        public CondicaoProduto CondicaoProduto { get; set; }

        public string CaminhoAbsoluto { get; set; }

        public string CaminhoRelativo { get; set; }

        public ViewFabricanteDto Fabricante { get; set; }

        public ViewSubCategoriaDto SubCategoria { get; set; }

        public Status Status { get; set; }
    }
}