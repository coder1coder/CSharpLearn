using System;
using System.Collections.Generic;
using System.Threading;

namespace Threading.SynchronizationPrimitives
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = new Logger();
            var warehouse = new Warehouse();
            
            var operatorDepartment = new OperatorDepartment(logger, warehouse);
            var deliveryDepartment = new DeliveryDepartment(logger, warehouse);

            IPrinter printer = new ConsolePrinter();
            
            warehouse.Run();

            _ = new Timer(_ => printer.DisplayInfo(deliveryDepartment, operatorDepartment, warehouse, logger), null,
                TimeSpan.Zero,
                TimeSpan.FromMilliseconds(200));

            var keyInfo = default(ConsoleKeyInfo);

            var departmentConsoleKeyMap = new Dictionary<ConsoleKey, IDepartment>
            {
                { ConsoleKey.D, deliveryDepartment },
                { ConsoleKey.O, operatorDepartment }
            };

            while (keyInfo.Key != ConsoleKey.Escape)
            {
                if (!Console.KeyAvailable)
                {
                    continue;
                }
                
                keyInfo = Console.ReadKey(true);

                if (departmentConsoleKeyMap.TryGetValue(keyInfo.Key, out var department))
                {
                    if (keyInfo.Modifiers == ConsoleModifiers.Shift)
                    {
                        department.RemoveEmployee();
                    }
                    else
                    {
                        department.AddEmployee();
                    }
                }
            }
            
            Console.WriteLine("Program finished");
            Console.ReadKey();
        }
    }
}