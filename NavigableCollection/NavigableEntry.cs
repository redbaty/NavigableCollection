namespace NavigableCollection
{
    public class NavigableEntry<T>
    {
        public T Previous { get; set; }
        
        public T Current { get; set; }
        
        public T Next { get; set; }
    }
}