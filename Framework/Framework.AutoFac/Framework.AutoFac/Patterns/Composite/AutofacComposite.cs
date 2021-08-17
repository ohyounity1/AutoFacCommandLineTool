using System;
using System.Collections.Generic;
using Autofac;
using Autofac.Builder;

namespace Framework.AutoFac.Patterns.Composite
{
    public static class AutofacComposite
    {
        public static IRegistrationBuilder<TService, SimpleActivatorData, SingleRegistrationStyle> RegisterComposite<TService>(this ContainerBuilder builder,
            Func<IComponentContext, IEnumerable<TService>, TService> composite,
            string fromKey)
        {
            var result = builder.Register(c => composite(c, c.ResolveNamed<IEnumerable<TService>>(fromKey))).As<TService>();
            return result;
        }
    }
}
