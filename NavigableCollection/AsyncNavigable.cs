using System.Collections.Generic;
using System.Threading;

namespace NavigableCollection
{
    public class AsyncNavigable<T> : IAsyncEnumerable<NavigableEntry<T>>
    {
        private readonly IAsyncEnumerable<T> _items;

        public AsyncNavigable(IAsyncEnumerable<T> items)
        {
            _items = items;
        }
        
        public IAsyncEnumerator<NavigableEntry<T>> GetAsyncEnumerator(CancellationToken cancellationToken = new CancellationToken())
        {
            return new AsyncNavigableEnumerator<T>(_items);
        }
    }
}