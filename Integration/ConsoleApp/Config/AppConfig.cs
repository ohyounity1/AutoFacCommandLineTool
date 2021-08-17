using Autofac;
using Libraries.Utility.Patterns;
using System.Reflection;
using ConsoleApp.Framework.CommandLine;
using System;
using System.Linq;
using Framework.Interceptor.Config;

namespace Console.Config
{
    public class AppConfig : SingletonBase<AppConfig>
    {
        private readonly IContainer _container;
        public IContainer Container => _container;

        private AppConfig()
        {
            var builder = new ContainerBuilder();

            var thisAssembly = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyModules(thisAssembly);
            if (CommandLineOptions.Instance.ForceGC)
                builder.RegisterModule(new Interceptor());
            _container = builder.Build();
        }
    }
}
