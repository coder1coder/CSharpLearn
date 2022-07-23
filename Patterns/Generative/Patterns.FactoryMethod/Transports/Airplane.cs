namespace Patterns.FactoryMethod.Transports
{
    public sealed class Airplane: ITransport
    {
        public string GetTypeName => "Самолёт";
    }
}