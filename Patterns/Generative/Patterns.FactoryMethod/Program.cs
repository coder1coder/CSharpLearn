using System;
using Patterns.FactoryMethod.Factories;

namespace Patterns.FactoryMethod
{
    internal static class Program
    {
        /// <summary>
        /// Фабричный метод — это порождающий паттерн проектирования, который определяет общий интерфейс для создания
        /// объектов в суперклассе, позволяя подклассам изменять тип создаваемых объектов.
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            var car = new CarFactory().Create();
            Console.WriteLine(car.GetTypeName);

            var airplane = new AirplaneFactory().Create();
            Console.WriteLine(airplane.GetTypeName);
        }
    }
}
