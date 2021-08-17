using System;
using Castle.DynamicProxy;

namespace Framework.Interceptor.Patterns
{
    public class GarbageCollectionInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            invocation.Proceed();
            System.Console.WriteLine($"Memory current allocated: ${GC.GetTotalMemory(true)}");
        }
    }
}
