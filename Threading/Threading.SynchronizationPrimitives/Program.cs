using System;

namespace Threading.SynchronizationPrimitives
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program started");
            var wh = new Warehouse();
            wh.Run();

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
                        wh.RemoveWarehouseStaff();
                    }
                    else
                    {
                        wh.AddWarehouseStaff();
                    }
                }
                
                if (keyInfo.Key == ConsoleKey.D)
                {
                    if (keyInfo.Modifiers == ConsoleModifiers.Shift)
                    {
                        wh.RemoveDeliveryman();
                    }
                    else
                    {
                        wh.AddDeliveryMan();
                    }
                }
            }
            
            Console.WriteLine("Program finished");
            Console.ReadKey();
        }
    }
}