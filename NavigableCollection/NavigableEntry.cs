namespace NavigableCollection
{
    public record NavigableEntry<T>
    {
        public T Previous { get; init; }
        
        public T Current { get; init; }
        
        public T Next { get; init; }
    }
}