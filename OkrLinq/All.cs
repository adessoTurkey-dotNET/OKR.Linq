namespace OkrLinq
{
    using System;
    using System.Collections.Generic;
    public static partial class MoreEnumerable
    {
        public static bool All<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (predicate == null)
            {
                throw new ArgumentNullException("predicate");
            }

            foreach (TSource item in source)
            {
                if (!predicate(item))
                {
                    return false;
                }
            }
            return true;
        }
    }
}