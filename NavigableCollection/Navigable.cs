using System.Collections;
using System.Collections.Generic;

namespace NavigableCollection
{
    public class Navigable<T> : IEnumerable<NavigableEntry<T>>
    {
        private readonly IEnumerable<T> _items;

        public Navigable(IEnumerable<T> items)
        {
            _items = items;
        }
        
        public IEnumerator<NavigableEntry<T>> GetEnumerator() => new NavigableEnumerator<T>(_items);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}