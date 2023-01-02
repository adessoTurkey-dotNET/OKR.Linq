namespace OkrLinq
{
    using System;
    using System.Collections.Generic;
    public static partial class MoreEnumerable
    {
        public static IEnumerable<TSource> DefaultIfEmpty<TSource>(
     this IEnumerable<TSource> source)
        {
            // This will perform an appropriate test for source being null first.
            return source.DefaultIfEmpty(default(TSource));
        }
        public static IEnumerable<TSource> DefaultIfEmpty<TSource>(
            this IEnumerable<TSource> source,
            TSource defaultValue)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            return DefaultIfEmptyImpl(source, defaultValue);
        }

        private static IEnumerable<TSource> DefaultIfEmptyImpl<TSource>(
            IEnumerable<TSource> source,
            TSource defaultValue)
        {
            bool foundAny = false;
            foreach (TSource item in source)
            {
                yield return item;
                foundAny = true;
            }
            if (!foundAny)
            {
                yield return defaultValue;
            }
        }
    }
}