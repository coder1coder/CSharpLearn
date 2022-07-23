using Patterns.AbstractFactory.Products.Spices;

namespace Patterns.AbstractFactory.Products.Dishes
{
    /// <summary>
    /// Борщ
    /// </summary>
    public class Rice: IDish
    {
        public string Use() => $"Use {nameof(Rice)}";
        public string UseWithSpice(ISpice spice) => $"Use {nameof(Rice)} with {spice.GetType().Name}";
    }
}