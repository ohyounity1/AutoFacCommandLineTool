using ConsoleApp.Framework.Console;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApp.Framework.Parser
{
    public class HelpWriter : TextWriter
    {
        private readonly IConsole _console;

        public override Encoding Encoding => Encoding.Default;

        public HelpWriter(IConsole console)
        {
            _console = console;
        }

        public override void Write(string value)
        {
            var split = value.Split(new[] { Environment.NewLine },
                StringSplitOptions.RemoveEmptyEntries);
            var rejoined = string.Join(Environment.NewLine, split.Skip(2));
            using(new HelpConsoleDecorator(_console))
                _console.WriteLine(rejoined);
        }
    }

}
