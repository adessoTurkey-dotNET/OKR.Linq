namespace OkrLinq
{
    using System;
    using System.Collections.Generic;
    public static partial class MoreEnumerable
    {
        public static IEnumerable<TSource> Distinct<TSource>(
      this IEnumerable<TSource> source)
        {
            return source.Distinct(EqualityComparer<TSource>.Default);
        }
        public static IEnumerable<TSource> Distinct<TSource>(
            this IEnumerable<TSource> source,
            IEqualityComparer<TSource> comparer)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            return DistinctImpl(source, comparer ?? EqualityComparer<TSource>.Default);
        }

        private static IEnumerable<TSource> DistinctImpl<TSource>(
            IEnumerable<TSource> source,
            IEqualityComparer<TSource> comparer)
        {
            HashSet<TSource> seenElements = new HashSet<TSource>(comparer);
            foreach (TSource item in source)
            {
                if (seenElements.Add(item))
                {
                    yield return item;
                }
            }
        }
    }
}