using Patterns.FactoryMethod.Transports;

namespace Patterns.FactoryMethod.Factories
{
    public sealed class CarFactory: TransportFactory
    {
        public override ITransport Create() => new Car();
    }
}