using CommandPattern.Core;
using CommandPattern.Core.Commands;
using CommandPattern.Core.Contracts;
using System.Data;

namespace CommandPattern
{
    public class StartUp
    {
        static void Main()
        {
            ICommandInterpreter command = new CommandInterpreter();
            IEngine engine = new Engine(command);
            engine.Run();

        }
    }
}