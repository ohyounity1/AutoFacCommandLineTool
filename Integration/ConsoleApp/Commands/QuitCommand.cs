using System;
using ConsoleApp.Framework.Commands;

namespace Console.Commands
{
    public class QuitCommand : ICommand
    {
        public bool BasicAllowed => true;

        public string Description => "Quits program";

        public string Name => "quit";

        public void Execute(string[] args)
        {
            Environment.Exit(0);
        }
    }

}
