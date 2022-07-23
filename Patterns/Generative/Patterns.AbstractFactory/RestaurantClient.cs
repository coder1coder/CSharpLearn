using System;
using Patterns.AbstractFactory.Products.Dishes;
using Patterns.AbstractFactory.Products.Spices;
using Patterns.AbstractFactory.Restaurants;

namespace Patterns.AbstractFactory
{
    public class RestaurantClient
    {
        private IDish _dish;
        private ISpice _spice;

        public void ReceiveOrder(IFoodRestaurant restaurant)
        {
            _dish = restaurant.MakeDish();
            _spice = restaurant.MakeSpice();
        }

        public void LookToOrder()
        {
            Console.WriteLine($"See dish: {_dish.GetType().Name}");
            Console.WriteLine($"See spice: {_spice.GetType().Name}");

            Console.WriteLine(_dish.Use());
            Console.WriteLine(_dish.UseWithSpice(_spice));

            Console.WriteLine(_spice.Use());
            Console.WriteLine(_spice.UseWithDish(_dish));
        }
    }
}