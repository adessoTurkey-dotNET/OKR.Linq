namespace OkrLinq
{
    using System;
    using System.Collections.Generic;
    public static partial class MoreEnumerable
    {

        public static IEnumerable<TResult> SelectMany<TSource, TResult>(
    this IEnumerable<TSource> source,
    Func<TSource, IEnumerable<TResult>> selector)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (selector == null)
            {
                throw new ArgumentNullException("selector");
            }
            return SelectManyImpl(source,
                                  (value, index) => selector(value),
                                  (originalElement, subsequenceElement) => subsequenceElement);
        }

        // Most complicated overload:
        // – Original projection takes index as well as value
        // – There’s a second projection for each original/subsequence element pair
        private static IEnumerable<TResult> SelectManyImpl<TSource, TCollection, TResult>(
            IEnumerable<TSource> source,
            Func<TSource, int, IEnumerable<TCollection>> collectionSelector,
            Func<TSource, TCollection, TResult> resultSelector)
        {
            int index = 0;
            foreach (TSource item in source)
            {
                foreach (TCollection collectionItem in collectionSelector(item, index++))
                {
                    yield return resultSelector(item, collectionItem);
                }
            }
        }
    }
}