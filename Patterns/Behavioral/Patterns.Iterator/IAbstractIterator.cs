namespace Patterns.Iterator
{
    public interface IAbstractIterator<out T>
    {
        T First();
        T Next();
        bool IsDone { get; }
        T CurrentItem { get; }
    }
}