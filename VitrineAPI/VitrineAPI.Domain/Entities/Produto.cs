using VitrineAPI.Domain.Entities.Base;

namespace VitrineAPI.Domain.Entities
{
    public class Produto : EntityBase
    {
        public string Nome { get; private set; }

        public int Valor { get; private set; }

        public int Quantidade { get; private set; }
    }
}