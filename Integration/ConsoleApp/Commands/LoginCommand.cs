using System;
using Autofac;
using CommandLine;
using Console.Properties;
using ConsoleApp.Framework.Console;
using ConsoleApp.Framework.Input;
using ConsoleApp.Framework.Prompt;
using ConsoleApp.Framework.User;
using ConsoleAppBase;

namespace Console.Commands
{
    public class LoginCommand : ConsoleProgram
    {
        private readonly ILifetimeScope _scope;
        private readonly UsersObserver _usersObserver;

        public LoginCommand(IConsole console,
            ILifetimeScope scope,
            UsersObserver usersObserver,
            Parser parser) : base(console, parser)
        {
            _scope = scope;
            _usersObserver = usersObserver;
        }

        public override string Description => "Login to the system";


        public override string Name => "login";

        public override bool BasicAllowed => true;

        public override void Execute(string[] args)
        {
            var username = string.Empty;
            using (var cmdScope = _scope.BeginLifetimeScope((c) =>
            {
                c.Register((ctx) => new CustomizedCommandPrompt(Resources.UserPrompt)).As<ICommandPrompt>();
                c.RegisterType<TrimInputModerator>().As<IInputModerator>();
            }))
            {
                var inputMgr = cmdScope.Resolve<InputManager>();
                do
                {
                    username = inputMgr.ReadInput();
                } while (string.IsNullOrEmpty(username));
            }
            var password = string.Empty;
            using (var cmdScope = _scope.BeginLifetimeScope((c) =>
             {
                 c.Register((ctx) => new CustomizedCommandPrompt(Resources.PasswordPrompt)).As<ICommandPrompt>();
                 c.RegisterType<TrimInputModerator>().As<IInputModerator>();
                 c.RegisterType<HideReadLineStrategy>().As<IReadLineStrategy>();
             }))
            {
                var inputMgr = cmdScope.Resolve<InputManager>();
                password = inputMgr.ReadInput();
            }
            var user = _usersObserver.GetUserByName(username);
            if (user == null || user.Password != password)
            {
                Console.WriteLine("Invalid username or password");
                return;
            }
            _usersObserver.User = user;
        }
    }
}
