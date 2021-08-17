using ConsoleApp.Framework.Console;
using System;

namespace ConsoleApp.Framework
{
    public class SystemConsole : IConsole
    {
        public ConsoleColor ConsoleColor
        {
            get
            {
                return System.Console.ForegroundColor;
            }
            set
            {
                System.Console.ForegroundColor = value;
            }
        }

        public void MoveCursorLeft()
        {
            var currentPos = System.Console.CursorLeft;
            System.Console.SetCursorPosition(currentPos - 1, System.Console.CursorTop);
        }

        public char Read()
        {
            var input = System.Console.ReadKey(true);
            return input.KeyChar;
        }

        public string ReadLine()
        {
            return System.Console.ReadLine();
        }

        public void Write(string output)
        {
            System.Console.Write(output);
        }

        public void WriteLine(string output)
        {
            System.Console.WriteLine(output);
        }
    }
}
