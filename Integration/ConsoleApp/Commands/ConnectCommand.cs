using System.Linq;
using CommandLine;
using ConsoleApp.Framework.Console;
using ConsoleAppBase;

namespace Console.Commands
{
    public class ConnectCommand : ConsoleProgram
    {
        public ConnectCommand(IConsole console, Parser parser) : base(console, parser)
        {
        }

        private enum ConnectionType
        {
            TCP,
            UDP
        }

        private class Options
        {
            [Option("ip", Required = true,
              HelpText = "IP Address destination")]
            public string IPAddress { get; set; }

            [Option("port", Required = false,
                HelpText = "Destination Port",
                DefaultValue = 8000)]
            public int Port { get; set; }

            [Option("type", 
                Required = false,
                HelpText = "Connection type",
                DefaultValue = ConnectionType.TCP)]
            public ConnectionType Type { get; set; }
        }

        public override bool BasicAllowed => false;

        public override string Description => "Connect to things";

        public override string Name => "connect";

        public override void Execute(string[] args)
        {
            var options = new Options();
            var results = ParseArguments(args, ref options);
            if (results != null && !results.Errors.Any())
            {
                Console.WriteLine($"Connecting to IP: {options.IPAddress}; Port: {options.Port}; Type: {options.Type}");
            }
        }
    }
}
