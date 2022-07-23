using Patterns.AbstractFactory.Products.Spices;

namespace Patterns.AbstractFactory.Products.Dishes
{
    public interface IDish
    {
        string Use();
        string UseWithSpice(ISpice spice);
    }
}