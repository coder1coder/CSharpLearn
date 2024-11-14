namespace Patterns.Iterator
{
    public class Iterator<T> : IAbstractIterator<T>
    {
        private readonly Collection<T> _collection;
        private int _current;

        public Iterator(Collection<T> collection)
        {
            _collection = collection;
        }

        public T First()
        {
            _current = 0;
            return _collection[_current];
        }
        
        public T Next()
        {
            _current += 1;
            return !IsDone ? _collection[_current] : default;
        }

        public T CurrentItem => _collection[_current];
        
        public bool IsDone => _current >= _collection.Count;
    }
}