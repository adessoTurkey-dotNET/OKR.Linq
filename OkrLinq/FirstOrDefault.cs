namespace OkrLinq
{
    using System;
    using System.Collections.Generic;
    public static partial class MoreEnumerable
    {
        public static TSource FirstOrDefault<TSource>(
      this IEnumerable<TSource> source)
        {
            // Argument validation elided
            using (IEnumerator<TSource> iterator = source.GetEnumerator())
            {
                return iterator.MoveNext() ? iterator.Current : default(TSource);
            }
        }
        public static TSource FirstOrDefault<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            // Argument validation elided
            foreach (TSource item in source)
            {
                if (predicate(item))
                {
                    return item;
                }
            }
            return default(TSource);
        }
    }
}