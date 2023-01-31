using VitrineAPI.Domain.Entities.Base;

namespace VitrineAPI.Domain.Entities
{
    public class SubCategoria : EntityBase
    {
        public string Nome { get; private set; }

        public string Descricao { get; private set; }

        public List<Categoria> Categorias { get; private set; }

        public List<Produto> Produtos { get; private set; }
    }
}