namespace OkrLinq
{
    using System;
    using System.Collections.Generic;
    public static partial class MoreEnumerable
    {
        public static TSource LastOrDefault<TSource>(
    this IEnumerable<TSource> source)
        {
            // Argument validation elided
            IList<TSource> list = source as IList<TSource>;
            if (list != null)
            {
                return list.Count == 0 ? default(TSource) : list[list.Count - 1]; 
            }
            TSource last = default(TSource);
            foreach (TSource item in source)
            {
                last = item;
            }
            return last;
        }

        public static TSource LastOrDefault<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            // Argument validation elided
            TSource last = default(TSource);
            foreach (TSource item in source)
            {
                if (predicate(item))
                {
                    last = item;
                }
            }
            return last;
        }
    }
}