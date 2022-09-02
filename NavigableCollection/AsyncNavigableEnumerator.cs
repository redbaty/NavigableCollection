using System.Collections.Generic;
using System.Threading.Tasks;

namespace NavigableCollection
{
    public class AsyncNavigableEnumerator<T> : IAsyncEnumerator<NavigableEntry<T>>
    {
        private IAsyncEnumerator<T> Enumerator { get; }
        private bool Last { get; set; }
        private int LastCount { get; set; }
        private bool Started { get; set; }
        private DropOutLinkedList<T> LoadedItems { get; } = new(3);
        
        public AsyncNavigableEnumerator(IAsyncEnumerable<T> items)
        {
            Enumerator = items.GetAsyncEnumerator();
        }
        
        private async Task<bool> MoveNextItemsAsync()
        {
            if (await Enumerator.MoveNextAsync())
            {
                LoadedItems.Push(Enumerator.Current);
                return true;
            }

            if (!Last)
            {
                Last = true;
                LoadedItems.Push(default);
            }

            return false;
        }
        
        public ValueTask DisposeAsync()
        {
            return Enumerator.DisposeAsync();
        }

        public async ValueTask<bool> MoveNextAsync()
        {
            if (!Started)
            {
                if (!await MoveNextItemsAsync())
                     return false;

                Started = true;
            }
            
            await MoveNextItemsAsync();
            
            Current = new NavigableEntry<T>
            {
                Previous = LoadedItems.AtIndex(2),
                Current = LoadedItems.AtIndex(1),
                Next = LoadedItems.AtIndex(0)
            };

            if (Last)
            {
                LastCount++;
            }
            
            return LastCount <= 1;
        }

        public NavigableEntry<T> Current { get; set; }
    }
}