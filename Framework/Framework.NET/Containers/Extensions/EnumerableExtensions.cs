using System;
using System.Collections.Generic;

namespace Framework.NET.Containers.Extensions
{
    public static class EnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> container, Action<T> action)
        {
            foreach(var item in container)
            {
                action(item);
            }
        }
    }
}
