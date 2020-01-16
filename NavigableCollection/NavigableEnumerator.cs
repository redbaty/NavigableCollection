using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NavigableCollection
{
    public class NavigableEnumerator<T> : IEnumerator<NavigableEntry<T>>
    {
        private ICollection<T> _items;
        private int _position = -1;

        public NavigableEnumerator(ICollection<T> items)
        {
            _items = items;
        }

        public NavigableEnumerator(IEnumerable<T> items)
        {
            _items = items is ICollection<T> itemsCollection ? itemsCollection : items.ToArray();
        }

        public bool MoveNext()
        {
            _position++;
            return _position < _items.Count;
        }

        public void Reset()
        {
            _position = -1;
        }

        public NavigableEntry<T> Current => new NavigableEntry<T>(_items.ElementAtOrDefault(_position - 1),
                _items.ElementAt(_position),
                _items.ElementAtOrDefault(_position + 1));

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            _items = null;
        }
    }
}