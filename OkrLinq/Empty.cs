namespace OkrLinq
{
    using System.Collections.Generic;

    public static partial class MoreEnumerable
    {
        public static IEnumerable<TResult> Empty<TResult>()
        {
            return EmptyEnumerable<TResult>.Instance;
        }

#if AVOID_RETURNING_ARRAYS
    private class EmptyEnumerable<T> : IEnumerable<T>, IEnumerator<T>
    {
        internal static IEnumerable<T> Instance = new EmptyEnumerable<T>();

        // Prevent construction elsewhere
        private EmptyEnumerable()
        {
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }

        public T Current
        {
            get { throw new InvalidOperationException(); }
        }

        object IEnumerator.Current
        {
            get { throw new InvalidOperationException(); }
        }

        public void Dispose()
        {
            // No-op
        }

        public bool MoveNext()
        {
            return false; // There’s never a next entry
        }

        public void Reset()
        {
            // No-op
        }
    }

#else
        private static class EmptyEnumerable<T>
        {
            internal static readonly T[] Instance = new T[0];
        }
#endif
    }
}
