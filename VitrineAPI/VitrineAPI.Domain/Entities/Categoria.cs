using VitrineAPI.Domain.Entities.Base;

namespace VitrineAPI.Domain.Entities
{
    public class Categoria : EntityBase
    {
        public string Nome { get; private set; }

        public string Descricao { get; private set; }

        public List<SubCategoria> SubCategorias { get; private set; }

        public void ListaSubcategoria(List<SubCategoria> subCategorias)
        {
            SubCategorias = subCategorias;
        }
    }
}