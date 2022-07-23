namespace Patterns.Builder
{
    internal abstract class VehicleBuilder
    {
        protected Vehicle vehicle;

        public Vehicle GetVehicle => vehicle;

        internal abstract void BuildFrame();
        internal abstract void BuildEngine();
        internal abstract void BuildWheels();
        internal abstract void BuildDoors();
    }
}