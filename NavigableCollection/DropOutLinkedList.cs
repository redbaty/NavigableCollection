using System.Collections.Generic;
using System.Linq;

namespace NavigableCollection
{
    internal class DropOutLinkedList<T>
    {
        private LinkedList<T> Items { get; }

        private int Capacity { get; }

        public DropOutLinkedList(int capacity)
        {
            Capacity = capacity;
            Items = new LinkedList<T>();
        }

        public void Push(T item)
        {
            Items.AddFirst(item);
            
            if (Items.Count > Capacity)
                Items.RemoveLast();
        }

        public T AtIndex(int index)
        {
            return Items.ElementAtOrDefault(index);
        }
    }
}