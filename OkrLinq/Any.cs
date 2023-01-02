namespace OkrLinq
{
    using System;
    using System.Collections.Generic;
    public static partial class MoreEnumerable
    {

        public static bool Any<TSource>(
     this IEnumerable<TSource> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            using (IEnumerator<TSource> iterator = source.GetEnumerator())
            {
                return iterator.MoveNext();
            }
        }
        public static bool Any<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (predicate == null)
            {
                throw new ArgumentNullException("predicate");
            }

            foreach (TSource item in source)
            {
                if (predicate(item))
                {
                    return true;
                }
            }
            return false;
        }

    }
}