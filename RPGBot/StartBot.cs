using System;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using RPGBot.Entity;
using RPGBot.Services;

namespace RPGBot
{
    internal class StartBot
    {
        private readonly DiscordSocketClient client;
        private readonly CommandService cmd;
        private readonly LogService log;
        private readonly ConfigService config;
        private readonly Config jsonConf;
        private IServiceProvider service;

        public StartBot()
        {
            client = new DiscordSocketClient(new DiscordSocketConfig
            {
                AlwaysDownloadUsers = true,
                LogLevel = LogSeverity.Debug,
                MessageCacheSize = 50
            });

            cmd = new CommandService(new CommandServiceConfig
            {
                LogLevel = LogSeverity.Verbose,
                CaseSensitiveCommands = false
            });

            log = new LogService();
            config = new ConfigService();
            jsonConf = config.GetConfig();
        }

        public async Task StartInit()
        {
            await client.LoginAsync(TokenType.Bot, jsonConf.token);
            await client.StartAsync();
            client.Log += LogAsync;
            service = SetupService();

            var cmdHandler = new CommandHandler(client, cmd, service);
            
        }

        private async Task LogAsync(LogMessage msg)
        {
            await log.LogAsync(msg);
        }

        private IServiceProvider SetupService()
            => new ServiceCollection()
            .AddSingleton(cmd)
            .AddSingleton(log)
            .AddSingleton(client)
            .BuildServiceProvider();
    }
}
