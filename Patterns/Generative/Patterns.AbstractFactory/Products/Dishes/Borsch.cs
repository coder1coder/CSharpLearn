using Patterns.AbstractFactory.Products.Spices;

namespace Patterns.AbstractFactory.Products.Dishes
{
    public class Borsch: IDish
    {
        public string Use() => $"Use {nameof(Borsch)}";
        public string UseWithSpice(ISpice spice) => $"Use {nameof(Borsch)} with {spice.GetType().Name}";
    }
}