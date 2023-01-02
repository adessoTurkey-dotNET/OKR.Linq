namespace OkrLinq
{
    using System;
    using System.Collections.Generic;
    public static partial class MoreEnumerable
    {
        public static TSource First<TSource>(
    this IEnumerable<TSource> source)
        {
            // Argument validation elided
            using (IEnumerator<TSource> iterator = source.GetEnumerator())
            {
                if (iterator.MoveNext())
                {
                    return iterator.Current;
                }
                throw new InvalidOperationException("Sequence was empty");
            }
        }
        public static TSource First<TSource>(
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
            throw new InvalidOperationException("No items matched the predicate");
        }
    }
}