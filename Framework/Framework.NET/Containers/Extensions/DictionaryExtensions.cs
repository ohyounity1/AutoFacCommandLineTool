using System;
using System.Collections.Generic;

namespace Framework.NET.Containers.Extensions
{
    public static class DictionaryExtensions
    {
        public static void ForEach<K, V>(this IDictionary<K,V> dictionary, Action<K, V> action)
        {
            foreach(var item in dictionary)
            {
                action(item.Key, item.Value);
            }
        }
    }
}
