namespace Patterns.FactoryMethod.Transports
{
    public sealed class Car : ITransport
    {
        public string GetTypeName => "Машина";
    }
}