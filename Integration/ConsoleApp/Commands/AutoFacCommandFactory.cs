using System.Collections.Generic;
using System.Linq;
using Autofac;
using ConsoleApp.Framework.Commands;
using ConsoleApp.Framework.User;

namespace Console.Commands
{
    public class AutoFacCommandFactory : ICommandFactory
    {
        private readonly ILifetimeScope _scope;

        private readonly IEnumerable<ICommand> _commands;
        private readonly HelpCommand _help;

        public AutoFacCommandFactory(ILifetimeScope scope)
        {
            _scope = scope;

            _commands = _scope.Resolve<IEnumerable<ICommand>>();
            _help = _scope.Resolve<HelpCommand>();
        }

        public IDictionary<string, ICommand> CreateCommands(IUser currentUser)
        {
            var validCmds = _commands.Where(c => currentUser.AllowCommand(c)).ToDictionary((c) => c.Name.ToLower());
            if (validCmds.ContainsKey(_help.Name))
                validCmds[_help.Name] = _help;
            return validCmds;
        }
    }
}
