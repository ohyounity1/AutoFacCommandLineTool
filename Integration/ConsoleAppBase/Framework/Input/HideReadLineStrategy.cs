using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApp.Framework.Console;

namespace ConsoleApp.Framework.Input
{
    public class HideReadLineStrategy : IReadLineStrategy
    {
        private readonly IConsole _console;

        public HideReadLineStrategy(IConsole console)
        {
            _console = console;
        }

        public string ReadLine()
        {
            char input;
            var inputStack = new Stack<char>();
            do
            {
                input = _console.Read();
                if(input == 8)
                {
                    if (inputStack.Any())
                    {
                        inputStack.Pop();
                        _console.MoveCursorLeft();
                        _console.Write(" ");
                        _console.MoveCursorLeft();
                    }
                }
                else if(input != 10 && input != 13)
                {
                    inputStack.Push(input);
                    _console.Write("*");
                }
            } while (input != 10 && input != 13);
            _console.WriteLine(string.Empty);
            return string.Join(string.Empty, inputStack.Reverse());
        }
    }
}
