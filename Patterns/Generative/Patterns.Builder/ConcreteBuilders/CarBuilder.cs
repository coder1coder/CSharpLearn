namespace Patterns.Builder.ConcreteBuilders
{
    internal class CarBuilder : VehicleBuilder
    {
        public CarBuilder()
        {
            vehicle = new Vehicle("Машина");
        }
        internal override void BuildDoors()
        {
            vehicle.DoorsCount = 4;
        }

        internal override void BuildEngine()
        {
            vehicle.EnginePower = 100;
        }

        internal override void BuildFrame()
        {
            vehicle.Frame = "Рама машины";
        }

        internal override void BuildWheels()
        {
            vehicle.WheelsDiameter = 16;
        }
    }
}