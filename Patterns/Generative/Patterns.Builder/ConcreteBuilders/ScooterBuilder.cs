namespace Patterns.Builder.ConcreteBuilders
{
    internal class ScooterBuilder : VehicleBuilder
    {
        public ScooterBuilder()
        {
            vehicle = new Vehicle("Скутер");
        }
        internal override void BuildDoors()
        {
            vehicle.DoorsCount = 0;
        }

        internal override void BuildEngine()
        {
            vehicle.EnginePower = 10;
        }

        internal override void BuildFrame()
        {
            vehicle.Frame = "Рама скутера";
        }

        internal override void BuildWheels()
        {
            vehicle.WheelsDiameter = 10;
        }
    }
}