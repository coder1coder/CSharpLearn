using Patterns.FactoryMethod.Transports;

namespace Patterns.FactoryMethod.Factories
{
    public sealed class AirplaneFactory: TransportFactory
    {
        public override ITransport Create() => new Airplane();
    }
}