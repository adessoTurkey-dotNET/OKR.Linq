namespace OkrLinq
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public static partial class MoreEnumerable
    {
        public static int Count<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            // Optimization for ICollection<T>
            ICollection<TSource> genericCollection = source as ICollection<TSource>;
            if (genericCollection != null)
            {
                return genericCollection.Count;
            }

            // Optimization for ICollection
            ICollection nonGenericCollection = source as ICollection;
            if (nonGenericCollection != null)
            {
                return nonGenericCollection.Count;
            }

            // Do it the slow way – and make sure we overflow appropriately
            checked
            {
                int count = 0;
                using (var iterator = source.GetEnumerator())
                {
                    while (iterator.MoveNext())
                    {
                        count++;
                    }
                }
                return count;
            }
        }
    }
}
