using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace RPGBot
{
    internal class Program
    {
        private DiscordSocketClient client;
        public string token { get; private set; }
        static void Main(string[] args)
            => new Program().MainAsync(args).ConfigureAwait(false).GetAwaiter().GetResult();

        private async Task MainAsync(string[] args)
        {
            client = new DiscordSocketClient();
            client.Log += Log;

            var token = new GetToken();

            await Task.Delay(-1);
        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
    }
}
