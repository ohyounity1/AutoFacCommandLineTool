using Autofac;
using ConsoleApp.Framework;
using ConsoleApp.Framework.Console;
using ConsoleApp.Framework.Parser;
using ConsoleApp.Framework.Prompt;
using Console.Properties;

namespace Console.Config
{
    public class Output : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SystemConsole>().As<IConsole>().SingleInstance();
            builder.Register((c) => new CustomizedCommandPrompt(Resources.CustomizedPrompt)).As<ICommandPrompt>().InstancePerLifetimeScope();
            /*builder.RegisterType<CustomizedCommandPrompt>().As<ICommandPrompt>().
              WithParameter(
                new ResolvedParameter((pi, ctx) => pi.ParameterType == typeof(string),
                (pi, ctx) => "oh, hai!"));*/

            //builder.RegisterType<HelpConsoleDecorator>().As<IConsoleDecorator>();
            builder.Register((c) => new CommandPromptDecorator(c.Resolve<IConsole>())).As<IConsoleDecorator>().ExternallyOwned();

            builder.RegisterType<HelpWriter>().AsSelf().SingleInstance();
        }
    }
}
