using System.Collections.Generic;

namespace Patterns.Iterator
{
    public class Collection<T>: IAbstractCollection<T>
    {
        private readonly List<T> _items = new();
        
        public Iterator<T> CreateIterator()
        {
            return new Iterator<T>(this);
        }
        
        public T this[int index]
        {
            get => _items[index];
            set => _items.Add(value);
        }
        
        public int Count => _items.Count;
    }
}