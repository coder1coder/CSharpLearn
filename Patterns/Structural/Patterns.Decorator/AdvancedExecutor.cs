using System;

namespace Patterns.Decorator
{
    public class AdvancedExecutor: Executor
    {
        private readonly Executor _defaultExecutor;
        
        public AdvancedExecutor(Executor executor)
        {
            _defaultExecutor = executor;
        }
        public override void Execute()
        {
            _defaultExecutor.Execute();
            Console.WriteLine("Advanced execution");
        }
    }
}