using System;
using ConsoleApp.Framework.Commands;

namespace Console.Commands
{
    public class HelpCommandDescription : ICommand
    {
        public bool BasicAllowed => true;
        
        public string Description => "Displays help";

        public string Name => "help";

        public virtual void Execute(string[] args)
        {
        }
    }
}
