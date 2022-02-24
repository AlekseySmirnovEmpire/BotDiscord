using RPGBot.Entity;
using System.IO;
using Newtonsoft.Json;

namespace RPGBot.Services
{
    internal class ConfigService
    {
        public Config GetConfig()
        {
            var text = File.ReadAllText("config.json");

            return JsonConvert.DeserializeObject<Config>(text);
        }
    }
}
