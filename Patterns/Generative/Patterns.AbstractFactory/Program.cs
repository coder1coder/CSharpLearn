using System;
using Patterns.AbstractFactory.Restaurants;

namespace Patterns.AbstractFactory
{
    internal static class Program
    {
        /// <summary>
        /// Абстрактная фабрика — это порождающий паттерн проектирования, который позволяет создавать семейства связанных
        /// объектов, не привязываясь к конкретным классам создаваемых объектов.
        /// </summary>
        static void Main(string[] args)
        {
            var client = new RestaurantClient();

            var restaurants = new IFoodRestaurant[]
            {
                new AsiaFoodRestaurant(),
                new RussianFoodRestaurant()
            };

            foreach (var restaurant in restaurants)
            {
                Console.WriteLine($"Go to {restaurant.GetType().Name}");

                client.ReceiveOrder(restaurant);
                client.LookToOrder();

                Console.WriteLine("Go out..\n");
            }
        }
    }
}
