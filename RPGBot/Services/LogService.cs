using Discord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RPGBot.Services
{
    internal class LogService
    {
        private readonly SemaphoreSlim mtx;

        public LogService()
        {
            mtx = new SemaphoreSlim(1);
        }

        internal async Task LogAsync(LogMessage msg)
        {
            await mtx.WaitAsync();

            var curTime = DateTime.UtcNow.ToString("MM/dd/yyyy hh:mm tt");
            const string format = "{0, -10} {1, 10}";

            Console.WriteLine($"[{curTime}] {string.Format(format, msg.Source, $": {msg.Message}")}");

            mtx.Release();
        }
    }
}
