namespace Threading.SynchronizationPrimitives
{
    public interface IPrinter
    {
        void Append(string text);
        void Append(char value);
        void AppendLine();
        void AppendLine(string text);

        void DisplayInfo(
            DeliveryDepartment deliveryDepartment, 
            OperatorDepartment operatorDepartment,
            Warehouse warehouse,
            Logger logger);
    }
}