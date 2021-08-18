using System.Collections.Generic;
using System.Linq;
using Autofac;
using ConsoleApp.Framework.Commands;
using ConsoleApp.Framework.User;

namespace Console.Commands
{
    public class AutoFacCommandFactory : ICommandFactory
    {
        private readonly IEnumerable<ICommand> _commands;

		private readonly HelpCommand _help;

		public AutoFacCommandFactory(IEnumerable<ICommand> commands,
			HelpCommand help)
        {
            _commands = commands;
			_help = help;
        }

        public IDictionary<string, ICommand> CreateCommands(IUser currentUser)
        {
            var validCmds = _commands.Where(c => currentUser.AllowCommand(c)).ToDictionary((c) => c.Name.ToLower());
			// Add help directly
			validCmds.Add(_help.Name, _help);
			return validCmds;
        }
    }
}
