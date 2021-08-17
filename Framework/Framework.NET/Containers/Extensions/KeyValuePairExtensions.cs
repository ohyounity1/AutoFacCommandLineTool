using System.Collections.Generic;

namespace Framework.NET.Containers.Extensions
{
    public static class KVP
    {
        public static KeyValuePair<K, V> Create<K,V>(K key, V value)
        {
            return new KeyValuePair<K, V>(key, value);
        }
    }
}
