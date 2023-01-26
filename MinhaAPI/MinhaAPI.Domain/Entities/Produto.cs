using MinhaAPI.Domain.Entities.Base;

namespace MinhaAPI.Domain.Entities
{
    public class Produto : EntityBase
    {
        public string Nome { get; private set; }

        public int Valor { get; private set; }

        public int Quantidade { get; private set; }
    }
}