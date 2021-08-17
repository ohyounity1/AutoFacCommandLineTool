using ConsoleApp.Framework.Console;
using System;

namespace ConsoleApp.Framework.Parser
{
    public class HelpConsoleDecorator : ConsoleColorDecoratorBase
    {
        public HelpConsoleDecorator(IConsole console) : base(console)
        {
            Console.ConsoleColor = ConsoleColor.Yellow;
        }
    }
}
