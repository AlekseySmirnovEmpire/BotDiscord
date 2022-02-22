using System;
using System.IO;
using Newtonsoft.Json.Linq;

namespace RPGBot
{
    internal class GetToken
    {
        static GetToken isCreated;
        
        private GetToken(){}

        static public string GenerateToken()
        {
            if(isCreated == null)
            {
                isCreated = new GetToken();

                var text = File.ReadAllText("config.json");
                var json = JObject.Parse(text);

                var token = json["token"].ToString();

                return token;
            }
            else
            {
                return null;
            }
        }
    }
}
