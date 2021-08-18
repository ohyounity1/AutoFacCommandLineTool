using System;
using System.Linq;
using ConsoleApp.Framework.Console;
using Console.Config;
using Autofac;
using ConsoleApp.Framework.Commands;
using ConsoleApp.Framework.Input;
using ConsoleApp.Framework.User;
using ConsoleApp.Framework.CommandLine;
using Microsoft.Extensions.Configuration;
using Autofac.Configuration;

namespace ConsoleApp
{
    class Program
    {
        private Program()
        {
           
        }

        
        static void Main(string[] args)
        {
			/*
            var program = new Program();
            program.Execute(args);*/

			// Add the configuration to the ConfigurationBuilder.
			var config = new ConfigurationBuilder();
			// config.AddJsonFile comes from Microsoft.Extensions.Configuration.Json
			// config.AddXmlFile comes from Microsoft.Extensions.Configuration.Xml
			config.AddJsonFile(@"Resources\config.json");

			// Register the ConfigurationModule with Autofac.
			var module = new ConfigurationModule(config.Build());
			var builder = new ContainerBuilder();
			builder.RegisterModule(module);

			var container = builder.Build();
		}

        protected void Execute(string[] args)
        {
            CommandLineOptions.Instance.ParseCommandLine(args, System.Console.Out);

            using (var scope = AppConfig.Instance.Container.BeginLifetimeScope())
            {
                var inputHandle = scope.Resolve<InputManager>();
                var factory = scope.Resolve<ICommandFactory>();
                
                var console = scope.Resolve<IConsole>();
                var usersObserver = scope.Resolve<UsersObserver>();

                var currentUser = usersObserver.User;
                var commands = factory.CreateCommands(currentUser);

                usersObserver.CurrentUserChangedEvent +=
                    (s, e) =>
                    {
                        commands = factory.CreateCommands(e.CurrentUser);
                    };
                do
                {
                    var input = inputHandle.ReadInput();
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
                                console.WriteLine("Did not find command: " + input);
                            }
                        }
                    }
                } while (true);
            }
        }
    }
}
