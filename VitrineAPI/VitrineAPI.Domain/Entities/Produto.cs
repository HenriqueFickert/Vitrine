using VitrineAPI.Domain.Entities.Base;
using VitrineAPI.Domain.Enum;

namespace VitrineAPI.Domain.Entities
{
    public class Produto : UploadIFormFileBase
    {
        public string Nome { get; private set; }

        public string Descricao { get; private set; }

        public int Valor { get; private set; }

        public int Quantidade { get; private set; }

        public CondicaoProduto CondicaoProduto { get; private set; }

        public SubCategoria SubCategoria { get; private set; }

        public Fabricante Fabricante { get; private set; }
    }
}