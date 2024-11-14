using System;

namespace Patterns.Composite
{
    public abstract class DefaultComponent
    {
        protected string Name { get; init; }

        protected DefaultComponent(string name)
        {
            Name = name;
        }

        public virtual void DoWork() => Console.WriteLine($"{Name} do work");
    }
}