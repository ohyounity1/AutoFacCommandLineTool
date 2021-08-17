using ConsoleApp.Framework.Console;

namespace ConsoleApp.Framework.Prompt
{
    public class CommandPromptDecorator : ConsoleColorDecoratorBase
    {
        public CommandPromptDecorator(IConsole console) : base(console)
        {
            console.ConsoleColor = System.ConsoleColor.White;
        }
    }
}
