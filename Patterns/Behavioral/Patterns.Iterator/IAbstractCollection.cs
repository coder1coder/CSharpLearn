namespace Patterns.Iterator
{
    public interface IAbstractCollection<T>
    {
        Iterator<T> CreateIterator();
    }
}