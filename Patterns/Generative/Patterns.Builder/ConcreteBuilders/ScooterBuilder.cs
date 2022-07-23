namespace Patterns.Builder.ConcreteBuilders
{
    internal class ScooterBuilder : VehicleBuilder
    {
        public ScooterBuilder()
        {
            Vehicle = new Vehicle("Скутер");
        }
        internal override void BuildDoors()
        {
            Vehicle.DoorsCount = 0;
        }

        internal override void BuildEngine()
        {
            Vehicle.EnginePower = 10;
        }

        internal override void BuildFrame()
        {
            Vehicle.Frame = "Рама скутера";
        }

        internal override void BuildWheels()
        {
            Vehicle.WheelsDiameter = 10;
        }
    }
}