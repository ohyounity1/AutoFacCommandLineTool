using ConsoleApp.Framework;
using ConsoleApp.Framework.Console;
using Libraries.Utility.Patterns;

namespace CommandLine
{
    public class Console : SingletonBase<Console>
    {
        public IConsole CurrentConsole { get; }

        private Console()
        {
            CurrentConsole = new SystemConsole();
        }
    }
}
