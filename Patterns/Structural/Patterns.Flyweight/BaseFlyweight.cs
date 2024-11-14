using System;

namespace Patterns.Flyweight
{
    public abstract class BaseFlyweight
    {
        public Guid Id = Guid.NewGuid();
        public void PrintId() => Console.WriteLine(Id);
    }
}