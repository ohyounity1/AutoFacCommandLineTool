using System;
using System.Collections.Generic;
using Castle.DynamicProxy;
using ConsoleApp.Framework.Commands;
using ConsoleApp.Framework.Console;
using ConsoleApp.Framework.User;
using Framework.NET.Containers.Extensions;

namespace Console.Commands
{
    public class HistoryCommand : ICommand, IInterceptor
    {
        private class HistoryMeta
        {
            public string Name { get; private set; }
            public DateTime ExecutionTime { get; private set; }
            public bool BasicAllowed { get; private set; }

            public HistoryMeta(string name, DateTime executionTime, bool basicAllowed)
            {
                Name = name;
                ExecutionTime = executionTime;
                BasicAllowed = basicAllowed;
            }

            public override string ToString()
            {
                return $"--- {Name}:   /{ExecutionTime}";
            }
        }

        private readonly Queue<HistoryMeta> _historyStack = new Queue<HistoryMeta>();
        private readonly IConsole _console;
        private readonly UsersObserver _users;
        private readonly int _maxHistoryItems;

        public bool BasicAllowed => true;

        public string Description => "Command history";

        public string Name => "history";

        public HistoryCommand(IConsole console, UsersObserver users, int maxHistoryItems)
        {
            _console = console;
            _users = users;
            _maxHistoryItems = maxHistoryItems;
        }

        public void AddCommandToHistory(ICommand command)
        {
            if (_historyStack.Count >= _maxHistoryItems)
                _historyStack.Dequeue();
            _historyStack.Enqueue(new HistoryMeta(command.Name, DateTime.Now, command.BasicAllowed));
        }

        public void Execute(string[] args)
        {
            var currentUser = _users.User;
            foreach(var command in _historyStack)
            {
                if (command.BasicAllowed || currentUser.Type == Users.Admin)
                    _console.WriteLine(command.ToString());
            }
            AddCommandToHistory(this);
        }

        public void Intercept(IInvocation invocation)
        {
            var command = invocation.InvocationTarget as ICommand;
            if(command != null)
            {
                if (invocation.Method.Name == nameof(ICommand.Execute))
                    AddCommandToHistory(command);
            }
            invocation.Proceed();
        }
    }
}
