using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace Threading.SynchronizationPrimitives
{
    public class Operator
    {
        private readonly Thread _thread;
        private readonly Warehouse _warehouse;
        private readonly Logger _logger;
        
        private readonly Action<long> _onAccessTimesReport;
        private readonly Action<long> _onWorkTimesReport;
        private readonly Action<long> _onWaitTimesReport;

        private TimeSpan WorkDuration { get; }
        public string Name { get; }
        
        public Operator(string name, TimeSpan workDuration, Warehouse warehouse, Logger logger, 
            Action<long> onAccessTimesReport, Action<long> onWaitTimesReport, Action<long> onWorkTimesReport = null)
        {
            Name = name;
            WorkDuration = workDuration;
            _warehouse = warehouse;
            _logger = logger;
            _onAccessTimesReport = onAccessTimesReport;
            _onWaitTimesReport = onWaitTimesReport;

            _onWorkTimesReport = onWorkTimesReport;

            _thread = new Thread(DoWork)
            {
                Name = name,
                IsBackground = true
            };
        }

        public void StartWork()
        {
            _thread.Start();
        }
        
        private bool CanDoWork()
        {
            return _warehouse.CanPickOrder();
        }
        
        private void DoWork()
        {
            do
            {
                IEnumerable<Order> pickedOrders = ArraySegment<Order>.Empty;
                
                var sw = new Stopwatch();

                if (CanDoWork())
                {
                    sw.Restart();
                    
                    _warehouse.RequestAccessForOperator();
                    
                    _onAccessTimesReport?.Invoke(sw.ElapsedMilliseconds);
                    sw.Restart();
                    
                    Thread.Sleep(WorkDuration);

                    _onWorkTimesReport?.Invoke(sw.ElapsedMilliseconds);
                    
                    pickedOrders = _warehouse.PickOrders(1);
                }
                else
                {
                    sw.Restart();
                    
                    _logger.Log($"operator {Thread.CurrentThread.Name} wait work");
                    Thread.Sleep(TimeSpan.FromMilliseconds(3_000));
                    
                    sw.Stop();
                    _onWaitTimesReport?.Invoke(sw.ElapsedMilliseconds);
                    _onWorkTimesReport?.Invoke(0);
                }

                var pickedOrdersCount = pickedOrders.Count();

                if (pickedOrdersCount > 0)
                {
                    _warehouse.NotifyFinishingForOperator();
                    _logger.Log($"operator {Thread.CurrentThread.Name} picked {pickedOrdersCount} orders.");
                }
                
            } while (_thread.IsAlive);
        }
    }
}