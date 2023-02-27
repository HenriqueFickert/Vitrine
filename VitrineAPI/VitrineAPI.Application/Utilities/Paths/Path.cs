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
                {"ProdutoDesenvolvimento", new Url { IP = "C:\\Users\\henri\\OneDrive\\Imagens\\ImagensBanco", DNS = "https://fickert.cloud/Arquivos/Imagem", SPLIT = "Imagem/"} },
                {"ProdutoProducao", new Url { IP = "h:\\root\\home\\henriquefickert-001\\www\\vitrinesite\\arquivos\\imagem\\produto", DNS = "https://fickert.cloud/Arquivos/Imagem", SPLIT = "Imagem/"} },
                {"UploadDesenvolvimento", new Url { IP = "C:\\Users\\henri\\OneDrive\\Imagens\\ImagensBanco", DNS = "https://fickert.cloud/Arquivos/Imagem", SPLIT = "Imagem/"} },
                {"UploadProducao", new Url { IP = "h:\\root\\home\\henriquefickert-001\\www\\vitrinesite\\arquivos\\imagem\\produto", DNS = "https://fickert.cloud/Arquivos/Imagem", SPLIT = "Imagem/"} },
            };
    }
}
