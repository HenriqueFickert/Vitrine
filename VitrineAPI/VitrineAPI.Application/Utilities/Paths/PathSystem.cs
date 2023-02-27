using Newtonsoft.Json;
using VitrineAPI.Domain.Enum;

namespace VitrineAPI.Application.Utilities.Paths
{
    public static class PathSystem
    {
        //public static Dictionary<string, Dictionary<string, string>> Paths { get; private set; }

        public static Path Path { get; set; }

        public static async Task<bool> ValidateURLs(string pathName, Ambiente ambiente)
        {
            string key = pathName + ambiente.ToString();

            if (!Path.Urls.ContainsKey(key) || Path.Urls[key] is null || String.IsNullOrEmpty(Path.Urls[key].IP) || String.IsNullOrEmpty(Path.Urls[key].DNS) || String.IsNullOrEmpty(Path.Urls[key].SPLIT))
                return false;

            await Task.CompletedTask;

            return true;
        }

        public static async Task<Url> GetURLs(string pathName, Ambiente environment)
        {
            string key = pathName + environment.ToString();

            if (!Path.Urls.ContainsKey(key))
                return null;

            await Task.CompletedTask;

            return Path.Urls[key];
        }

        //public static async Task GetUrlJson()
        //{
        //    //TODO: Pegar o caminho root talvez?
        //    string json = File.ReadAllText(Directory.GetCurrentDirectory() + "\\Urls.json");
        //    Paths = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(json);
        //    await Task.CompletedTask;
        //}

        //public static async Task<bool> ValidateURLs(string pathName, Ambiente ambiente)
        //{
        //    string key = pathName + ambiente.ToString();

        //    if (!Paths.ContainsKey(key) || !Paths[key].ContainsKey("IP") || !Paths[key].ContainsKey("DNS") || !Paths[key].ContainsKey("SPLIT"))
        //        return false;

        //    await Task.CompletedTask;

        //    return true;
        //}

        //public static async Task<Dictionary<string, string>> GetURLs(string pathName, Ambiente environment)
        //{
        //    string key = pathName + environment.ToString();

        //    if (!Paths.ContainsKey(key))
        //        return null;

        //    await Task.CompletedTask;

        //    return Paths[key];
        //}
    }
}