using Patterns.Builder.ConcreteBuilders;

namespace Patterns.Builder
{
    internal class Program
    {
        /// <summary>
        /// Строитель - порождающий паттерн проектирования, который позволяет разделить процесс создания нового
        /// экземпляра сложного объекта на отдельные этапы.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var manufacturer = new Manufacturer();

            VehicleBuilder builder = new ScooterBuilder();
            Manufacturer.Construct(builder);
            builder.GetVehicle.Show();

            builder = new CarBuilder();
            Manufacturer.Construct(builder);
            builder.GetVehicle.Show();
        }
    }
}
