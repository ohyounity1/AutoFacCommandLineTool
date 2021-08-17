namespace Framework.NET.Patterns
{
    public class NoFinalizerPolicy : IFinalizerPolicy
    {
        public bool ImplementsFinalizer => false;
    }
}
