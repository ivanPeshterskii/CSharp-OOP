using LoggerLibrary.Core;
using LoggerLibrary.Core.Interfaces;

namespace LoggerLibrary;
class Program
{
    static void Main(string[] args)
    {
        IEngine engine = new Engine();
        engine.Run();
    }
}

