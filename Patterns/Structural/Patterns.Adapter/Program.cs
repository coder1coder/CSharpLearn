using System;

namespace Patterns.Adapter
{
    class Program
    {
        /// <summary>
        /// Адаптер — это структурный паттерн проектирования,
        /// который позволяет объектам с несовместимыми интерфейсами работать вместе.
        /// </summary>
        static void Main(string[] _)
        {
            var number = 0;
            var stringAdapter = new StringAdapter(ref number);
            Console.WriteLine(stringAdapter.GetValueAsString());
        }
    }
}