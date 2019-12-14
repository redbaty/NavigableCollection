using System;
using System.Collections;
using System.Collections.Generic;

namespace NavigableCollection
{
    public class NavigableEntry<T>
    {
        public T Previous { get; set; }
        
        public T Current { get; set; }
        
        public T Next { get; set; }
    }
    
    public class Navigable<T> : List<NavigableEntry<T>>
    {
        public Navigable(IEnumerable<T> items)
        {
            AddRange(BuildCollection(items));
        }

        private IEnumerable<NavigableEntry<T>> BuildCollection(IEnumerable<T> items)
        {
            T pastItem = default;
            NavigableEntry<T> pastEntry = default;
            
            foreach (var currentItem in items)
            {
                var entry = new NavigableEntry<T>
                {
                    Previous = pastItem,
                    Current = currentItem
                };
                
                if (pastEntry != null)
                {
                    pastEntry.Next = entry.Current;
                }

                yield return entry;

                pastItem = currentItem;
                pastEntry = entry;
            }
        }
    }
}