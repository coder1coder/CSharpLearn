using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading;

namespace Threading.SynchronizationPrimitives
{
    public class Warehouse
    {
        private const int MaxBoxes = 100_000;
        private ConcurrentQueue<int> _boxesQueue = new();
        private readonly ConcurrentStack<Thread> _deliverymen = new();
        private readonly ConcurrentStack<Thread> _warehouseStaff = new();
        
        private readonly ConcurrentQueue<string> _log = new();
        
        
        
        public void Run()
        {
            _boxesQueue = new ConcurrentQueue<int>();

            _ = new Timer(_ => DisplayInfo(), null, TimeSpan.Zero, TimeSpan.FromMilliseconds(200));
        }

        public void AddWarehouseStaff()
        {
            var worker = new Thread(WarehouseStaffWork)
            {
                Name = $"{_warehouseStaff.Count + 1}",
                IsBackground = true
            };
            
            _warehouseStaff.Push(worker);
            
            LogInformation($"worker #{worker.Name} added");
            worker.Start();
        }

        public void RemoveWarehouseStaff()
        {
            if (_warehouseStaff.TryPop(out var worker))
            {
                LogInformation($"worker #{worker.Name} was removed");    
            }
            else
            {
                LogInformation("No any worker to remove");
            }
        }

        private void WarehouseStaffWork()
        {
            while (_warehouseStaff.Contains(Thread.CurrentThread))
            {
                Thread.Sleep(3_000);
                
                if (_boxesQueue.TryDequeue(out var value))
                {
                    LogInformation($"staff {Thread.CurrentThread.Name} put box #{value}. Queue count: {_boxesQueue.Count}");
                }
                else
                {
                    LogInformation($"staff {Thread.CurrentThread.Name} wait, no any boxes");
                }
            }
        }

        public void AddDeliveryMan()
        {
            var worker = new Thread(DeliveryManWork)
            {
                Name = $"{_deliverymen.Count + 1}",
                IsBackground = true
            };
            
            _deliverymen.Push(worker);
            
            LogInformation($"deliveryman #{worker.Name} added");
            worker.Start();
        }
        
        public void RemoveDeliveryman()
        {
            if (_deliverymen.TryPop(out var worker))
            {
                LogInformation($"deliveryman #{worker.Name} was removed");    
            }
            else
            {
                LogInformation("No any deliverymen to remove");
            }
        }

        private void DeliveryManWork()
        {
            while (_deliverymen.Contains(Thread.CurrentThread))
            {
                if (_boxesQueue.Count < MaxBoxes)
                {
                    _boxesQueue.Enqueue(_boxesQueue.Count + 1);
                    LogInformation($"deliveryman #{Thread.CurrentThread.Name} delivery box. Queue count: {_boxesQueue.Count}");
                }
                else
                {
                    LogInformation($"deliveryman #{Thread.CurrentThread.Name} couldn't put box. Warehouse limit.");
                }

                Thread.Sleep(3_000);
            }
        }

        private void DisplayInfo()
        {
            Console.Clear();
            
            const string keyInfo = "D - add deliveryman (+shift to remove), S - add worker (+shift to remove), ESC - exit ";

            var output = new StringBuilder();
            output.AppendLine(keyInfo);
            output.AppendLine();

            WriteBoxesInfo(output);
            output.AppendLine();
            
            output.AppendLine($"Deliverymen: {_deliverymen.Count}");
            output.AppendLine($"Workers: {_warehouseStaff.Count}");
            output.AppendLine();
            
            foreach (var message in _log)
            {
                output.AppendLine(message);
            }

            Console.WriteLine(output.ToString());
        }

        private void WriteBoxesInfo(StringBuilder output)
        {
            var percent = (double)_boxesQueue.Count / MaxBoxes * 100.00;
            
            output.AppendLine($"Boxes in warehouse: {_boxesQueue.Count} (max: {MaxBoxes}, {percent:F} %)");
            
            var values = Convert.ToInt32(Math.Round(20 / 100.00 * percent, MidpointRounding.ToNegativeInfinity));
            
            output.Append('[');

            for (var i = 0; i < values; i++)
            {
                output.Append('=');
            }

            for (var i = 0; i < 20 - values; i++)
            {
                output.Append(' ');
            }
            
            output.AppendLine("]");
        }

        private void LogInformation(string message)
        {
            _log.Enqueue(message);
            if (_log.Count > 5)
            {
                _log.TryDequeue(out _);
            }
        }
    }
}