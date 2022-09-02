using System.Collections.Generic;

namespace NavigableCollection
{
    public static class NavigableExtensions
    {
        public static Navigable<T> ToNavigable<T>(this IEnumerable<T> baseCollection) => new(baseCollection);
        
        public static AsyncNavigable<T> ToNavigable<T>(this IAsyncEnumerable<T> baseCollection) => new(baseCollection);
    }
}