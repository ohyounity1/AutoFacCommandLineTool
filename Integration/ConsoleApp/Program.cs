using Autofac;
using ConsoleApp.Framework.CommandLine;
using Microsoft.Extensions.Configuration;
using Autofac.Configuration;
using Console;

namespace ConsoleApp
{
	class Program
    {
        static void Main(string[] args)
        {
			CommandLineOptions.Instance.ParseCommandLine(args, System.Console.Out);

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

			var shell = container.Resolve<MainShell>();
			shell.Execute();
		}
    }
}
