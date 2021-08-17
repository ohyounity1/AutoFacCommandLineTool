using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApp.Framework;
using ConsoleApp.Framework.Commands;
using ConsoleApp.Framework.Console;
using ConsoleApp.Framework.Input;
using ConsoleApp.Framework.Prompt;

namespace QuickStart
{
    class Program
    {
        private readonly IDictionary<string, ICommand> _commands = new Dictionary<string, ICommand>();

        private Program()
        { }

        static void Main(string[] args)
        {
            new Program().Run(args);
        }

        private void Run(string[] args)
        {/*
            var console = CommandLine.Console.Instance.CurrentConsole;
            var inputHandle = new InputManager(console);

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
                        if (_commands.TryGetValue(cmdName, out cmd))
                        {
                            cmd.Execute(split.Length == 1 ? new string[] { } : split.Skip(1).ToArray());
                        }
                        else
                        {
                            console.WriteLine("Did not find command: " + input);
                        }
                    }
                }
            } while (true) ;*/
        }

    }


}