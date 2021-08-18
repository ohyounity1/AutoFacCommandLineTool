using ConsoleAppBase;
using CommandLine;
using System.Linq;
using ConsoleApp.Framework.Console;

namespace ConsoleApp.LoggingIntegration
{
    public class LoggingProgram : ConsoleProgram
    {
        public LoggingProgram(IConsole console,
            Parser parser) : base(console, parser)
        {
        }

        private class Options
        {
            [Option('4', "log4net", Required = false,
              HelpText = "Test with log4net.")]
            public bool Log4NetTest { get; set; }
        }

        public override string Description => "Tests Logging Functionality";

        public override string Name => "LogTest";

        public override bool BasicAllowed => false;

        public override void Execute(string[] args)
        {
            var options = new Options();
            var results = ParseArguments(args, ref options);
            if(results != null && !results.Errors.Any())
            {
                Console.WriteLine("oh, hi!");
                if (options.Log4NetTest)
                    Console.WriteLine("Enjoy log4net!");
            }
        }
    }
}
