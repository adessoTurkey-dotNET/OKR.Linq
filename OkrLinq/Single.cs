namespace OkrLinq
{
    using System;
    using System.Collections.Generic;
    public static partial class MoreEnumerable
    {
        public static TSource Single<TSource>(
     this IEnumerable<TSource> source)
        {
            // Argument validation elided
            using (IEnumerator<TSource> iterator = source.GetEnumerator())
            {
                if (!iterator.MoveNext())
                {
                    throw new InvalidOperationException("Sequence was empty");
                }
                TSource ret = iterator.Current;
                if (iterator.MoveNext())
                {
                    throw new InvalidOperationException("Sequence contained multiple elements");
                }
                return ret;
            }
        }
        public static TSource Single<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            // Argument validation elided
            TSource ret = default(TSource);
            bool foundAny = false;
            foreach (TSource item in source)
            {
                if (predicate(item))
                {
                    if (foundAny)
                    {
                        throw new InvalidOperationException("Sequence contained multiple matching elements");
                    }
                    foundAny = true;
                    ret = item;
                }
            }
            if (!foundAny)
            {
                throw new InvalidOperationException("No items matched the predicate");
            }
            return ret;
        }
    }
}