namespace OkrLinq
{
    using System;
    using System.Collections.Generic;

    public static partial class MoreEnumerable
    {
        public static TAccumulate Aggregate<TSource, TAccumulate>(
        this IEnumerable<TSource> source,
        TAccumulate seed,
        Func<TAccumulate, TSource, TAccumulate> func)
        {
            return source.Aggregate(seed, func, x => x);
        }
        public static TResult Aggregate<TSource, TAccumulate, TResult>(
            this IEnumerable<TSource> source,
            TAccumulate seed,
            Func<TAccumulate, TSource, TAccumulate> func,
            Func<TAccumulate, TResult> resultSelector)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (func == null)
            {
                throw new ArgumentNullException("func");
            }
            if (resultSelector == null)
            {
                throw new ArgumentNullException("resultSelector");
            }
            TAccumulate current = seed;
            foreach (TSource item in source)
            {
                current = func(current, item);
            }
            return resultSelector(current);
        }
    }
}