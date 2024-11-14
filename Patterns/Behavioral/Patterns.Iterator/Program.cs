using System;

namespace Patterns.Iterator
{
    class Program
    {
        /// <summary>
        /// Итератор — это поведенческий паттерн проектирования,
        /// который даёт возможность последовательно обходить элементы составных объектов,
        /// не раскрывая их внутреннего представления.
        /// </summary>
        static void Main(string[] _)
        {
            var collection = new Collection<string>
            {
                [0] = new ("Item 0"),
                [1] = new ("Item 1"),
                [2] = new ("Item 2"),
                [3] = new ("Item 3"),
                [4] = new ("Item 4"),
                [5] = new ("Item 5"),
                [6] = new ("Item 6"),
                [7] = new ("Item 7"),
                [8] = new ("Item 8")
            };
            
            var iterator = collection.CreateIterator();

            for (var item = iterator.First(); !iterator.IsDone; item = iterator.Next())
            {
                Console.WriteLine(item);
            }
        }
    }
}