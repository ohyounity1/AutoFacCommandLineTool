using System;

namespace Libraries.Utility.Patterns
{
    public class SingletonBase<T> where T: class
    {
        private static Lazy<T> _instance = new Lazy<T>(() => Activator.CreateInstance(typeof(T), true) as T);

        public static T Instance
        {
            get
            {
                return _instance.Value;
            }
        }
    }
}
