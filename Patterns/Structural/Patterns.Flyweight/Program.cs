namespace Patterns.Flyweight
{
    class Program
    {
        /// <summary>
        /// Легковес — это структурный паттерн, который экономит память, благодаря разделению общего состояния,
        /// вынесенного в один объект, между множеством объектов.
        /// </summary>
        static void Main(string[] _)
        {
            var factory = new FlyweightFactory();
            var flyweightA = factory.GetFlyweight(nameof(FlyweightA));
            flyweightA.PrintId();
            
            flyweightA = factory.GetFlyweight(nameof(FlyweightA));
            flyweightA.PrintId();

            var flyweightB = factory.GetFlyweight(nameof(FlyweightB));
            flyweightB.PrintId();
        }
    }
}