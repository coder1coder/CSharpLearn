using System;
using System.Threading;

namespace Patterns.Singleton
{
    internal static class Program
    {
        /// <summary>
        /// Одиночка — это порождающий паттерн проектирования, который гарантирует,
        /// что у класса есть только один экземпляр, и предоставляет к нему глобальную точку доступа.
        /// </summary>
        static void Main()
        {
            new Thread(() =>
            {
                SingletonDatabase.DatabaseInstance.AddValue(Guid.NewGuid().ToString());
                Console.WriteLine(".");
            }).Start();

            while (true)
            {
                foreach (var city in SingletonDatabase.DatabaseInstance.GetCities())
                    Console.WriteLine(city);
            }
        }
    }
}
