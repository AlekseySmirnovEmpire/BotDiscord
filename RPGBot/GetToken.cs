using System;
using System.IO;
using Newtonsoft.Json.Linq;

namespace RPGBot
{
    internal class GetToken
    {
        public readonly string tokenValue;
        public readonly string prefixValue;
        public GetToken()
        {
            var text = File.ReadAllText("config.json");
            var json = JObject.Parse(text);

            tokenValue = json["token"].ToString();
            prefixValue = json["prefix"].ToString();
        }
    }
}
