using System;

namespace Patterns.Decorator
{
    public class Executor
    {
        public virtual void Execute()
        {
            Console.WriteLine("Default execution");
        }
    }
}