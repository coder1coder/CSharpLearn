using Patterns.AbstractFactory.Products.Dishes;
using Patterns.AbstractFactory.Products.Spices;

namespace Patterns.AbstractFactory.Restaurants
{
    public class RussianFoodRestaurant: IFoodRestaurant
    {
        public ISpice MakeSpice()
            => new Salt();

        public IDish MakeDish()
            => new Borsch();
    }
}