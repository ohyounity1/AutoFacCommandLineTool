using System;

namespace ConsoleApp.Framework.Console
{
    public class ErrorConsoleDecorator : ConsoleColorDecoratorBase
    {
        public ErrorConsoleDecorator(IConsole console) : base(console)
        {
            console.ConsoleColor = ConsoleColor.Red;
        }
    }
}
