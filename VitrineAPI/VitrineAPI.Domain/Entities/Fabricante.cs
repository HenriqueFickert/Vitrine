using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VitrineAPI.Domain.Entities.Base;

namespace VitrineAPI.Domain.Entities
{
    public class Fabricante : UploadIFormFileBase
    {
        public string Nome { get; private set; }

        public string Descricao { get; private set; }

        public int CNPJ { get; private set; }

        public List<Produto> Produtos { get; private set; }
    }
}
