namespace OkrLinq
{
    using System;
    using System.Collections.Generic;
    public static partial class MoreEnumerable
    {

        public static IEnumerable<TResult> Select<TSource, TResult>(
    this IEnumerable<TSource> source,
    Func<TSource, TResult> selector)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (selector == null)
            {
                throw new ArgumentNullException("selector");
            }
            return SelectImpl(source, selector);
        }
        private static IEnumerable<TResult> SelectImpl<TSource, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, TResult> selector)
        {
            foreach (TSource item in source)
            {
                yield return selector(item);
            }
        }

        public static IEnumerable<TSource> Select<TSource>(
       this IEnumerable<TSource> source,
       Func<TSource, int, bool> predicate)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (predicate == null)
            {
                throw new ArgumentNullException("predicate");
            }
            return SelectImpl(source, predicate);
        }
        private static IEnumerable<TSource> SelectImpl<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, int, bool> predicate)
        {
            int index = 0;
            foreach (TSource item in source)
            {
                if (predicate(item, index))
                {
                    yield return item;
                }
                index++;
            }
        }
    }
}