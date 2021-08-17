using System.Collections.Generic;
using Autofac;
using Autofac.Core;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Console.Commands;
using ConsoleApp.Framework.Commands;
using ConsoleApp.LoggingIntegration;
using Framework.Interceptor.Patterns;

namespace Console.Config
{
    public class Commands : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<QuitCommand>().As<ICommand>().SingleInstance().EnableInterfaceInterceptors().InterceptedBy(typeof(HistoryCommand));
            builder.RegisterType<LoginCommand>().As<ICommand>().SingleInstance().EnableInterfaceInterceptors().InterceptedBy(typeof(HistoryCommand));
            builder.RegisterType<HelpCommandDescription>().As<ICommand>().SingleInstance().EnableInterfaceInterceptors().InterceptedBy(typeof(HistoryCommand));
            builder.RegisterType<LoggingProgram>().As<ICommand>().SingleInstance().EnableInterfaceInterceptors().InterceptedBy(typeof(HistoryCommand));
            builder.RegisterType<ConnectCommand>().As<ICommand>().SingleInstance().EnableInterfaceInterceptors().InterceptedBy(typeof(HistoryCommand));
            builder.RegisterType<HelpCommand>().AsSelf().SingleInstance();
            builder.RegisterType<HistoryCommand>().As<ICommand>().As<IInterceptor>().As<HistoryCommand>().SingleInstance().WithParameter("maxHistoryItems", 20);

            builder.RegisterType<AutoFacCommandFactory>().As<ICommandFactory>().SingleInstance();
        }
    }
}
