using VitrineAPI.Domain.Entities.Base;

namespace VitrineAPI.Domain.Entities
{
    public class Fabricante : EntityBase
    {
        public string Nome { get; private set; }

        public string Descricao { get; private set; }

        public string CNPJ { get; private set; }

        public List<Produto> Produtos { get; private set; }
    }
}