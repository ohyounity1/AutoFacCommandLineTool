using System;

namespace Libraries.Utility.Patterns
{
    public class Notify<T>
    {
        private T _value;

        private readonly Action _propertyChanged;

        public Notify(Action propertyChanged)
        {
            _propertyChanged = propertyChanged;
        }

        public T Value
        {
            get { return _value; }
            set
            {
                if(!Equals(_value, value))
                {
                    _value = value;
                    _propertyChanged?.Invoke();
                }
            }
        }
    }
}
