using Patterns.AbstractFactory.Products.Dishes;

namespace Patterns.AbstractFactory.Products.Spices
{
    public class Pepper: ISpice
    {
        public string Use() => $"Use {nameof(Pepper)}";
        public string UseWithDish(IDish dish) => $"Use {nameof(Pepper)} with {dish.GetType().Name}";
    }
}