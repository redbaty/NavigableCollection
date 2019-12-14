using System.Collections.Generic;

namespace NavigableCollection
{
    public static class NavigableExtensions
    {
        public static Navigable<T> ToNavigable<T>(this IEnumerable<T> baseCollection) =>
            new Navigable<T>(baseCollection);
    }
}