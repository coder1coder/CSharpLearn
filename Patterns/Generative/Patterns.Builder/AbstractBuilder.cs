namespace Patterns.Builder
{
    internal abstract class VehicleBuilder
    {
        protected Vehicle Vehicle;

        public Vehicle GetVehicle => Vehicle;

        internal abstract void BuildFrame();
        internal abstract void BuildEngine();
        internal abstract void BuildWheels();
        internal abstract void BuildDoors();
    }
}