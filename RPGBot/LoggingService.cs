using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RPGBot
{
    internal class LoggingService
    {
        public LoggingService(DiscordSocketClient client, CommandService cmd)
        {
            client.Log += LogAsync;
            cmd.Log += LogAsync;
        }

        private Task LogAsync(LogMessage msg)
        {
            if (msg.Exception is CommandException cmdExp)
            {
                Console.WriteLine($"[Command/{msg.Severity}] {cmdExp.Command.Aliases.First()}" +
                    $" faild to execute in {cmdExp.Context.Channel}");
                Console.WriteLine(cmdExp);
            }
            else
                Console.WriteLine($"[General/{msg.Severity}] {msg}");

            return Task.CompletedTask;
        }
    }
}
