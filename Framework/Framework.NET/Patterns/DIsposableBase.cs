using System;

namespace Framework.NET.Patterns
{
    public abstract class DisposableBase<FP> : IDisposable where FP : IFinalizerPolicy, new()
    {

        private readonly FP _finalizerPolicy = new FP();

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected abstract void DisposeManagedResources();
        protected virtual void DisposeUnmanagedResources() { }
        protected virtual void NullifyLargeFields() { }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    DisposeManagedResources();
                }

                DisposeUnmanagedResources();
                NullifyLargeFields();

                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            if(_finalizerPolicy.ImplementsFinalizer)
                GC.SuppressFinalize(this);
        }
        #endregion
    }

    public abstract class DisposableBase : DisposableBase<NoFinalizerPolicy>
    {

    }

    public abstract class FinalizerBase : DisposableBase<HasFinalizerPolicy>
    {
        ~FinalizerBase()
        {
            Dispose(false);
        }
    }
}
