using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading;

namespace Threading.SynchronizationPrimitives
{
    public class DeliveryManagement
    {
        private readonly ConcurrentStack<Thread> _deliverymen = new();
        private readonly Logger _logger;
        private readonly Warehouse _warehouse;
        
        public DeliveryManagement(Logger logger, Warehouse warehouse)
        {
            _logger = logger;
            _warehouse = warehouse;
        }
        
        public void AddWorker()
        {
            var worker = new Thread(DoWork)
            {
                Name = $"{_deliverymen.Count + 1}",
                IsBackground = true
            };
            
            _deliverymen.Push(worker);
            
            _logger.Log($"deliveryman #{worker.Name} added");
            worker.Start();
        }
        
        public void RemoveWorker()
        {
            if (_deliverymen.TryPop(out var worker))
            {
                _logger.Log($"deliveryman #{worker.Name} was removed");    
            }
            else
            {
                _logger.Log("No any deliverymen to remove");
            }
        }

        private bool CanDoWork()
        {
            return _warehouse.CanPutOrder();
        }
        
        private void DoWork()
        {
            while (_deliverymen.Contains(Thread.CurrentThread))
            {
                if (CanDoWork())
                {
                    _warehouse.PutOrders(new[]{ new Order()});

                    _logger.Log($"deliveryman #{Thread.CurrentThread.Name} delivered order.");
                }
                else
                {
                    _logger.Log($"deliveryman #{Thread.CurrentThread.Name} couldn't put order.");
                }

                Thread.Sleep(3_000);
            }
        }

        public void PrintInfo(StringBuilder output)
        {
            output.AppendLine($"Deliverymen: {_deliverymen.Count}");
        }
    }
}