using Patterns.AbstractFactory.Products.Dishes;
using Patterns.AbstractFactory.Products.Spices;

namespace Patterns.AbstractFactory.Restaurants
{
    public interface IFoodRestaurant
    {
        ISpice MakeSpice();
        IDish MakeDish();
    }
}