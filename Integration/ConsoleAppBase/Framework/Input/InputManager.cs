using System;
using ConsoleApp.Framework.Console;
using ConsoleApp.Framework.Prompt;

namespace ConsoleApp.Framework.Input
{
    public class InputManager
    {
        private readonly IConsole _console;
        private readonly IReadLineStrategy _readLineStrategy;
        private readonly ICommandPrompt _prompt;
        private readonly IInputModerator _moderator;
        private readonly Func<IConsole, IConsoleDecorator> _decoratorF;


        public InputManager(IConsole console,
            ICommandPrompt prompt,
            IReadLineStrategy readLineStretegy,
            IInputModerator moderator,
            Func<IConsole, IConsoleDecorator> decoratorF)
        {
            _console = console;
            _prompt = prompt;
            _readLineStrategy = readLineStretegy;
            _moderator = moderator;
            _decoratorF = decoratorF;
        }
        /*
        public InputManager(IConsole console)
        {
            _console = console;
            _prompt = new DateTimeStampPrompt((c) => new HelpConsoleDecorator(c));
            _readLineStrategy = new BasicReadLineStrategy(_console);
            _moderator = new TrimInputModerator();
        }*/
        public string ReadInput()
        {
            using(_decoratorF(_console))
                _console.Write(_prompt.Prompt);
            var input = _readLineStrategy.ReadLine();
            return _moderator.Modify(input);
        }

    }
}
