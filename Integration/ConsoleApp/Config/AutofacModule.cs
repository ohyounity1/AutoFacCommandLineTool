using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using CommandLine;
using Console.Commands;
using Console.Properties;
using ConsoleApp.Framework;
using ConsoleApp.Framework.Commands;
using ConsoleApp.Framework.Console;
using ConsoleApp.Framework.Input;
using ConsoleApp.Framework.Parser;
using ConsoleApp.Framework.Prompt;
using ConsoleApp.Framework.User;
using ConsoleApp.LoggingIntegration;
using Framework.AutoFac.Patterns.Composite;

namespace Console.Config
{
	public class AutofacModule : Module
	{
		private void LoadCommands(ContainerBuilder builder)
		{
			builder.RegisterType<LoginCommand>().As<ICommand>().SingleInstance().EnableInterfaceInterceptors().InterceptedBy(typeof(HistoryCommand));
			builder.RegisterType<LoggingProgram>().As<ICommand>().SingleInstance().EnableInterfaceInterceptors().InterceptedBy(typeof(HistoryCommand));
			builder.RegisterType<ConnectCommand>().As<ICommand>().SingleInstance().EnableInterfaceInterceptors().InterceptedBy(typeof(HistoryCommand));
			builder.RegisterType<HelpCommand>().AsSelf().SingleInstance().EnableClassInterceptors().InterceptedBy(typeof(HistoryCommand));
			builder.RegisterType<HistoryCommand>().As<ICommand>().As<IInterceptor>().As<HistoryCommand>().SingleInstance().WithParameter("maxHistoryItems", 20);

			builder.RegisterType<QuitCommand>().As<ICommand>().SingleInstance().EnableInterfaceInterceptors().InterceptedBy(typeof(HistoryCommand));

			builder.RegisterType<AutoFacCommandFactory>().As<ICommandFactory>().SingleInstance();
		}

		private void LoadInputModules(ContainerBuilder builder)
		{
			builder.RegisterType<InputManager>().InstancePerLifetimeScope();

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

		private void LoadOutputModules(ContainerBuilder builder)
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

		private void LoadUserModules(ContainerBuilder builder)
		{
			builder.RegisterType<BasicUser>().As<IUser>().SingleInstance();
			builder.RegisterType<AdminUser>().As<IUser>().SingleInstance();

			builder.RegisterType<UsersObserver>().AsSelf().SingleInstance();
		}

		protected override void Load(ContainerBuilder builder)
		{
			LoadCommands(builder);
			LoadInputModules(builder);
			LoadOutputModules(builder);
			LoadUserModules(builder);

			builder.RegisterType<MainShell>().AsSelf().SingleInstance();
		}
	}
}
