namespace Patterns.Builder.ConcreteBuilders
{
    internal class CarBuilder : VehicleBuilder
    {
        public CarBuilder()
        {
            Vehicle = new Vehicle("Машина");
        }
        internal override void BuildDoors()
        {
            Vehicle.DoorsCount = 4;
        }

        internal override void BuildEngine()
        {
            Vehicle.EnginePower = 100;
        }

        internal override void BuildFrame()
        {
            Vehicle.Frame = "Рама машины";
        }

        internal override void BuildWheels()
        {
            Vehicle.WheelsDiameter = 16;
        }
    }
}