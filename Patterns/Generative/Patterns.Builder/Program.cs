using Patterns.Builder.ConcreteBuilders;

namespace Patterns.Builder
{
    internal class Program
    {
        /// <summary>
        /// Строитель - порождающий паттерн проектирования, который позволяет разделить процесс создания нового экземпляра сложного объекта на отдельные этапы.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            VehicleBuilder builder;

            Manufacturer manufacturer = new Manufacturer();

            builder = new ScooterBuilder();
            manufacturer.Construct(builder);
            builder.GetVehicle.Show();

            builder = new CarBuilder();
            manufacturer.Construct(builder);
            builder.GetVehicle.Show();
        }
    }
}
