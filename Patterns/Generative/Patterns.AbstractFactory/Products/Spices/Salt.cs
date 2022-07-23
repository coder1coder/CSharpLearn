using Patterns.AbstractFactory.Products.Dishes;

namespace Patterns.AbstractFactory.Products.Spices
{
    public class Salt: ISpice
    {
        public string Use() => $"Use {nameof(Salt)}";
        public string UseWithDish(IDish dish) => $"Use {nameof(Salt)} with {dish.GetType().Name}";
    }
}