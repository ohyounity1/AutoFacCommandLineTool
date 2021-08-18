using ConsoleApp.Framework.Commands;
using ConsoleApp.Framework.Console;
using ConsoleApp.Framework.Input;
using ConsoleApp.Framework.User;
using System;
using System.Linq;

namespace Console
{
	public class MainShell
	{
		private readonly InputManager _inputManager;

		private readonly ICommandFactory _commandFactory;
		private readonly IConsole _console;

		private readonly UsersObserver _usersObserver;

		public MainShell(InputManager inputManager,
			ICommandFactory commandFactory,
			IConsole console,
			UsersObserver usersObserver)
		{
			_inputManager = inputManager;
			_commandFactory = commandFactory;
			_console = console;
			_usersObserver = usersObserver;
		}

		public void Execute()
		{
			var currentUser = _usersObserver.User;
			var commands = _commandFactory.CreateCommands(currentUser);

			_usersObserver.CurrentUserChangedEvent +=
				(s, e) =>
				{
					commands = _commandFactory.CreateCommands(e.CurrentUser);
				};
			do
			{
				var input = _inputManager.ReadInput();
				if (!string.IsNullOrEmpty(input))
				{
					var split = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
					if (split.Length > 0)
					{
						ICommand cmd = null;
						var cmdName = split[0];
						if (commands.TryGetValue(cmdName, out cmd))
						{
							cmd.Execute(split.Length == 1 ? new string[] { } : split.Skip(1).ToArray());
						}
						else
						{
							_console.WriteLine("Did not find command: " + input);
						}
					}
				}
			} while (true);
		}
	}
}
