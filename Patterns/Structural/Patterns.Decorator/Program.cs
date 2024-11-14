using System;

namespace Patterns.Decorator
{
    class Program
    {
        /// <summary>
        /// Декоратор — это структурный паттерн проектирования,
        /// который позволяет динамически добавлять объектам новую функциональность,
        /// оборачивая их в полезные «обёртки».
        /// </summary>
        static void Main(string[] _)
        {
            var simpleExecutor = new Executor();
            simpleExecutor.Execute();

            var advancedExecutor = new AdvancedExecutor(simpleExecutor);
            advancedExecutor.Execute();
        }
    }
}