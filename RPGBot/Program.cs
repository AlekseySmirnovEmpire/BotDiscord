using System.Threading.Tasks;

namespace RPGBot
{
    internal class Program
    {
        static async Task Main(string[] args)
            => await new StartBot().StartInit();
    }
}
