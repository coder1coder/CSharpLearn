using Patterns.AbstractFactory.Products.Dishes;

namespace Patterns.AbstractFactory.Products.Spices
{
    public interface ISpice
    {
        string Use();
        string UseWithDish(IDish dish);
    }
}