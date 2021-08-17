using Framework.NET.Patterns;
using System;

namespace ConsoleApp.Framework.Console
{
    public abstract class ConsoleColorDecoratorBase : DisposableBase, IConsoleDecorator
    {
        private readonly IConsole _console;
        private readonly ConsoleColor _originalColor;

        protected IConsole Console => _console;

        protected ConsoleColorDecoratorBase(IConsole console)
        {
            _console = console;
            _originalColor = _console.ConsoleColor;
        }

        protected override void DisposeManagedResources()
        {
            _console.ConsoleColor = _originalColor;
        }
    }
}
