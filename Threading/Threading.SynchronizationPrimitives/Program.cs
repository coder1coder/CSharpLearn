using System;
using System.Text;
using System.Threading;

namespace Threading.SynchronizationPrimitives
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program started");
            var logger = new Logger();
            var warehouse = new Warehouse();
            var operatorManagement = new OperatorManagement(logger, warehouse);
            var deliveryManagement = new DeliveryManagement(logger, warehouse);
            warehouse.Run();
            
            _ = new Timer(_ => DisplayInfo(deliveryManagement, operatorManagement, warehouse, logger), null, TimeSpan.Zero, TimeSpan.FromMilliseconds(200));

            var keyInfo = default(ConsoleKeyInfo);

            while (keyInfo.Key != ConsoleKey.Escape)
            {
                if (!Console.KeyAvailable)
                {
                    continue;
                }
                
                keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.W)
                {
                    if (keyInfo.Modifiers == ConsoleModifiers.Shift)
                    {
                        operatorManagement.RemoveWorker();
                    }
                    else
                    {
                        operatorManagement.AddWorker();
                    }
                }
                
                if (keyInfo.Key == ConsoleKey.D)
                {
                    if (keyInfo.Modifiers == ConsoleModifiers.Shift)
                    {
                        deliveryManagement.RemoveWorker();
                    }
                    else
                    {
                        deliveryManagement.AddWorker();
                    }
                }
            }
            
            Console.WriteLine("Program finished");
            Console.ReadKey();
        }
        
        private static void DisplayInfo(
            DeliveryManagement deliveryManagement, 
            OperatorManagement operatorManagement,
            Warehouse warehouse,
            Logger logger)
        {
            Console.Clear();
            
            const string keyInfo = "D - add deliveryman (+shift to remove), S - add worker (+shift to remove), ESC - exit ";

            var output = new StringBuilder();
            output.AppendLine(keyInfo);
            output.AppendLine();

            warehouse.PrintInfo(output);
            output.AppendLine();
            
            deliveryManagement.PrintInfo(output);
            operatorManagement.PrintInfo(output);
            output.AppendLine();
            
            logger.PrintMessages(output);

            Console.WriteLine(output.ToString());
        }
    }
}