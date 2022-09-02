using System.Collections;
using System.Collections.Generic;

namespace NavigableCollection
{
    public class NavigableEnumerator<T> : IEnumerator<NavigableEntry<T>>
    {
        private IEnumerator<T> Enumerator { get; }
        private int Position { get; set; } = -1;
        private bool Last { get; set; }
        private int LastCount { get; set; }
        private DropOutLinkedList<T> LoadedItems { get; } = new(3);

        private bool MoveItemsNext()
        {
            if (Enumerator.MoveNext())
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

        public bool MoveNext()
        {
            if (Position < 0)
            {
                if (!MoveItemsNext())
                    return false;
            }

            Position++;
            MoveItemsNext();
            
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

        public NavigableEnumerator(IEnumerable<T> items)
        {
            Enumerator = items.GetEnumerator();
        }

        public void Reset()
        {
            Position = -1;
            Enumerator.Reset();
        }

        public NavigableEntry<T> Current { get; set; }

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            Enumerator.Dispose();
        }
    }
}