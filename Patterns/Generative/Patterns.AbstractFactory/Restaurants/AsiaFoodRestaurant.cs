using Patterns.AbstractFactory.Products.Dishes;
using Patterns.AbstractFactory.Products.Spices;

namespace Patterns.AbstractFactory.Restaurants
{
    public class AsiaFoodRestaurant: IFoodRestaurant
    {
        public ISpice MakeSpice()
            => new Pepper();

        public IDish MakeDish()
            => new Rice();
    }
}