using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VitrineAPI.Domain.Pagination
{
    public class ParametersProduto : ParametersPalavraChave
    {
        public List<Guid> subcategoriasId { get; set; }
    }
}
