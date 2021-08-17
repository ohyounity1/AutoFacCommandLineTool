using Autofac;
using Castle.DynamicProxy;
using Framework.Interceptor.Patterns;

namespace Framework.Interceptor.Config
{
    public class Interceptor : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<GarbageCollectionInterceptor>().As<IInterceptor>();
        }
    }
}
