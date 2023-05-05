using VitrineAPI.Domain.Entities.Base;

namespace VitrineAPI.Domain.Entities
{
    public class Upload : UploadIFormFileBase
    {
        public Guid TipoImagemId { get; private set; }

        public List<Produto> Produtos { get; private set; }

        public List<Fabricante> Fabricantes { get; private set; }

        public TipoImagem TipoImagem { get; private set; }
    }
}