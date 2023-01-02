namespace OkrLinq
{
    using System;
    using System.Collections.Generic;
    public static partial class MoreEnumerable
    {
        public static TSource Last<TSource>(
     this IEnumerable<TSource> source)
        {
            // Argument validation elided
            IList<TSource> list = source as IList<TSource>;
            if (list != null)
            {
                if (list.Count == 0)
                {
                    throw new InvalidOperationException("Sequence was empty");
                }
                return list[list.Count - 1];
            }
            using (IEnumerator<TSource> iterator = source.GetEnumerator())
            {
                if (!iterator.MoveNext())
                {
                    throw new InvalidOperationException("Sequence was empty");
                }
                TSource last = iterator.Current;
                while (iterator.MoveNext())
                {
                    last = iterator.Current;
                }
                return last;
            }
        }

        public static TSource Last<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            // Argument validation elided
            bool foundAny = false;
            TSource last = default(TSource);
            foreach (TSource item in source)
            {
                if (predicate(item))
                {
                    foundAny = true;
                    last = item;
                }
            }
            if (!foundAny)
            {
                throw new InvalidOperationException("No items matched the predicate");
            }
            return last;
        }
    }
}