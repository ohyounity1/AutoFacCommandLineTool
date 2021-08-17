using Autofac;
using Autofac.Core;
using CommandLine;
using Console.Properties;
using ConsoleApp.Framework.Input;
using ConsoleApp.Framework.Parser;
using Framework.AutoFac.Patterns.Composite;

namespace Console.Config
{
    public class Input : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<InputManager>().InstancePerLifetimeScope();
            
            //builder.RegisterType<TrimInputModerator>().As<IInputModerator>().SingleInstance();
            builder.RegisterType<TrimInputModerator>().Named<IInputModerator>(Resources.InputModerators).SingleInstance();
            builder.RegisterType<LowerInputModerator>().Named<IInputModerator>(Resources.InputModerators).SingleInstance();
            builder.RegisterComposite<IInputModerator>((c, inners) => new MultiInputModerator(inners), Resources.InputModerators).SingleInstance();

            builder.RegisterType<BasicReadLineStrategy>().As<IReadLineStrategy>().InstancePerLifetimeScope();

            builder.Register(c =>
                new Parser((o) =>
                {
                    o.CaseSensitive = true;
                    o.EnableDashDash = true;
                    o.IgnoreUnknownArguments = true;
                    o.HelpWriter = c.Resolve<HelpWriter>();
                })).SingleInstance();
        }
    }
}
