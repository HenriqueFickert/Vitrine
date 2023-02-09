using VitrineAPI.Domain.Entities.Base;

namespace VitrineAPI.Domain.Entities
{
    public class SubCategoria : EntityBase
    {
        public Guid CategoriaId { get; private set; }

        public string Nome { get; private set; }

        public string Descricao { get; private set; }

        public Categoria Categoria { get; private set; }

        public List<Produto> Produtos { get; private set; }
    }
}