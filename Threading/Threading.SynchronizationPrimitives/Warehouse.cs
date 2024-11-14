using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace Threading.SynchronizationPrimitives
{
    public class Warehouse
    {
        private const int OrdersLimit = 1_000;
        private ConcurrentQueue<Order> _ordersQueue = new();

        private const int PutOrderAccessMax = 5;
        private const int PickOrderAccessMax = 5;

        private readonly SemaphoreSlim _putOrderAccess = new(1, PutOrderAccessMax);
        private readonly SemaphoreSlim _pickOrderAccess = new(1, PickOrderAccessMax);

        public void Run()
        {
            _ordersQueue = new ConcurrentQueue<Order>();
        }

        public void PrintInfo(IPrinter output)
        {
            var percent = (double)_ordersQueue.Count / OrdersLimit * 100.00;
            
            output.AppendLine($"Orders: {_ordersQueue.Count} (max: {OrdersLimit}, {percent:F} %)");

            const int barSize = 50;
            
            var values = Convert.ToInt32(Math.Round(barSize / 100.00 * percent, MidpointRounding.ToNegativeInfinity));
            
            output.Append('[');

            for (var i = 0; i < values; i++)
            {
                output.Append('=');
            }

            for (var i = 0; i < barSize - values; i++)
            {
                output.Append('-');
            }
            
            output.AppendLine("]");
        }

        public bool CanPutOrder()
        {
            return _ordersQueue.Count < OrdersLimit;
        }

        public void PutOrders(Order[] orders)
        {
            foreach (var order in orders)
            {
                _ordersQueue.Enqueue(order);    
            }
        }

        public bool CanPickOrder()
        {
            return !_ordersQueue.IsEmpty;
        }

        public IEnumerable<Order> PickOrders(int count)
        {
            for (var i = 0; i < count; i++)
            {
                _ordersQueue.TryDequeue(out var order);
                yield return order;
            }
        }
        
        public void RequestAccessForDeliveryman()
        {
            _putOrderAccess.Wait();
        }

        public void NotifyFinishingForDeliveryman()
        {
            _putOrderAccess.Release();
        }

        public void RequestAccessForOperator()
        {
            _pickOrderAccess.Wait();
        }

        public void NotifyFinishingForOperator()
        {
            _pickOrderAccess.Release();
        }
    }
}