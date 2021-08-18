using CommandLine;
using System.Linq;
using ConsoleApp.Framework.Console;
using ConsoleApp.Framework.Commands;
using System;

namespace ConsoleAppBase
{
	public abstract class ConsoleProgram : ICommand
	{
		public abstract string Description { get; }

		public abstract string Name { get; }

		public abstract void Execute(string[] args);

		public abstract bool BasicAllowed { get; }

		private readonly IConsole _console;
		private readonly Parser _parser;
		protected IConsole Console => _console;



		protected ConsoleProgram(IConsole console,
			Parser parser)
		{
			_console = console;
			_parser = parser;
		}

		protected ParserResult<Options> ParseArguments<Options>(string[] args,
			ref Options options) where Options : new()
		{
			try
			{
				var results = _parser.ParseArguments<Options>(args.ToArray());
				if (!results.Errors.Any())
				{
					options = results.Value;
				}
				else
				{
					foreach (var error in results.Errors)
					{
						switch (error.Tag)
						{
							case ErrorType.HelpRequestedError:
							case ErrorType.HelpVerbRequestedError:
								continue;
							default:
								_console.WriteLine(error.Tag.ToString());
								break;
						}
					}
				}
				return results;
			}
			catch (Exception e)
			{
				return null;
			}
		}
    }
}
