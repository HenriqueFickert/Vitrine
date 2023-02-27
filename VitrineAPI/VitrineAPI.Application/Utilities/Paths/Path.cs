using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VitrineAPI.Application.Utilities.Paths
{
    public class Path
    {
        public readonly static Dictionary<string, Url> Urls = new()
            {
                {"ProdutoProducao", new Url { IP = "", DNS = "", SPLIT = ""} }
            };
    }
}
