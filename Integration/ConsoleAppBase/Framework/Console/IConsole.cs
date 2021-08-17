using System;

namespace ConsoleApp.Framework.Console
{
    public interface IConsole
    {
        string ReadLine();
        char Read();
        void WriteLine(string output);
        void Write(string output);
        void MoveCursorLeft();
        ConsoleColor ConsoleColor { get;  set; }
    }
}
