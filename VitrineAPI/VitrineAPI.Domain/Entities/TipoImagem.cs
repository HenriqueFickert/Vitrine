using VitrineAPI.Domain.Entities.Base;

namespace VitrineAPI.Domain.Entities
{
    public class TipoImagem : EntityBase
    {
        public string Nome { get; private set; }

        public List<Upload> Uploads { get; private set; }
    }
}