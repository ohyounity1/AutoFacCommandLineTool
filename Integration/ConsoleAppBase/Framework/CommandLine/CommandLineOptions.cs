using System;
using System.IO;
using System.Linq;
using CommandLine;
using ConsoleApp.Framework.Console;
using Libraries.Utility.Patterns;
using CommandLineNamespace = CommandLine;

namespace ConsoleApp.Framework.CommandLine
{
    public class CommandLineOptions : SingletonBase<CommandLineOptions>
    {
        private class Options
        {
            [Option("gcforce")]
            public bool ForceGC { get; set; }
        }

        private Options _options;

        public bool ForceGC => _options.ForceGC;

        public bool ParseCommandLine(string[] args, TextWriter console)
        {
            var parser = CommandLineNamespace.Parser.Default;
            var results = parser.ParseArguments<Options>(
                Environment.CommandLine.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Skip(1).ToArray());
            if (!results.Errors.Any())
            {
                _options = results.Value;
                return true;
            }
            else
            {
                console.WriteLine("ERROR: Cannot parse the arguments: " + string.Join("; ", args));
                return false;
            }
        }

        private CommandLineOptions()
        {
            
        }
    }
}
