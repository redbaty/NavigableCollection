namespace NavigableCollection
{
    public class NavigableEntry<T>
    {
        internal NavigableEntry(T previous, T current, T next)
        {
            Previous = previous;
            Current = current;
            Next = next;
        }

        public T Current { get; }

        public T Next { get; }

        public T Previous { get; }
    }
}