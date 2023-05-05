using VitrineAPI.Domain.Entities.Base;

namespace VitrineAPI.Domain.Entities
{
    public class Produto : EntityBase
    {
        public Guid SubCategoriaId { get; private set; }

        public Guid FabricanteId { get; private set; }

        public string Nome { get; private set; }

        public string Descricao { get; private set; }

        public int Valor { get; private set; }

        public int Quantidade { get; private set; }

        public string CondicaoProduto { get; private set; }

        public SubCategoria SubCategoria { get; private set; }

        public Fabricante Fabricante { get; private set; }

        public List<Upload> Uploads { get; private set; }

        public void AlterarUploads(List<Upload> uploads)
        {
            Uploads = uploads;
        }
    }
}