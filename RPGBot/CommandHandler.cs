using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGBot
{
    internal class CommandHandler
    {
        private readonly DiscordSocketClient client;
        private readonly CommandService cmd;
        private readonly IServiceProvider service;

        public CommandHandler(DiscordSocketClient client, CommandService cmd, IServiceProvider service)
        {
            this.client = client;
            this.cmd = cmd;
            this.service = service;
        }


    }
}
