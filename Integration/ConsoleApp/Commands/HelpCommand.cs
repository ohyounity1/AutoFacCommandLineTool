using ConsoleApp.Framework.Console;
using Framework.NET.Containers.Extensions;
using System;
using System.Collections.Generic;
using ConsoleApp.Framework.Commands;
using ConsoleApp.Framework.User;
using System.Linq;
using ConsoleApp.Framework.Parser;

namespace Console.Commands
{
    public class HelpCommand : HelpCommandDescription
    {
        private readonly IEnumerable<ICommand> _commands;
        private readonly IConsole _console;
        private readonly UsersObserver _usersObserver;

        public HelpCommand(IEnumerable<ICommand> commands, 
            IConsole console,
            UsersObserver usersObserver)
        {
            _commands = commands;
            _console = console;
            _usersObserver = usersObserver;
        }

        public override void Execute(string[] args)
        {
            base.Execute(args);
            using (new HelpConsoleDecorator(_console))
            {
                _console.WriteLine("Following are available: ");
                var currentUser = _usersObserver.User;
                _commands.Where(c => currentUser.AllowCommand(c)).ForEach((c) => _console.WriteLine($"{c.Name} : {c.Description}"));
            }
        }
    }
}
