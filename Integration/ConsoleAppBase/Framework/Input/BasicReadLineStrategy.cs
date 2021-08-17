using ConsoleApp.Framework.Console;

namespace ConsoleApp.Framework.Input
{
    public class BasicReadLineStrategy : IReadLineStrategy
    {
        private readonly IConsole _console;

        public BasicReadLineStrategy(IConsole console)
        {
            _console = console;
        }

        public string ReadLine()
        {
            return _console.ReadLine();
        }
    }
}
