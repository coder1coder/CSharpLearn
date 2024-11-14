using System;
using System.Diagnostics;
using System.Threading;

namespace Threading.SynchronizationPrimitives
{
    public class Deliveryman
    {
        private readonly Thread _thread;
        private readonly Warehouse _warehouse;
        private readonly Logger _logger;
        private readonly string _name;
        private readonly TimeSpan _workDuration;
        
        private readonly Action<long> _onAccessTimesReport;
        private readonly Action<long> _onWorkTimesReport;
        private readonly Action<long> _onWaitTimesReport;
        
        public EmployeeState State { get; private set; } 
        
        public Deliveryman(string name, TimeSpan workDuration, Warehouse warehouse, Logger logger, 
            Action<long> onAccessTimesReport, Action<long> onWaitTimesReport, Action<long> onWorkTimesReport = null)
        {
            _name = name;
            _workDuration = workDuration;
            State = EmployeeState.Idle;
            
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
            return _warehouse.CanPutOrder();
        }
        
        private void DoWork()
        {
            do
            {
                var sw = new Stopwatch();

                var deliveredOrders = 0;

                if (CanDoWork())
                {
                    sw.Restart();
                    
                    State = EmployeeState.Waiting;
                    
                    _warehouse.RequestAccessForDeliveryman();
                    
                    _onAccessTimesReport?.Invoke(sw.ElapsedMilliseconds);
                    sw.Restart();
                    
                    State = EmployeeState.Working;

                    Thread.Sleep(_workDuration);

                    _onWorkTimesReport?.Invoke(sw.ElapsedMilliseconds);

                    var orders = new[] { new Order() };
                    _warehouse.PutOrders(orders);
                    deliveredOrders = orders.Length;
                }
                else
                {
                    sw.Restart();
                    
                    Thread.Sleep(TimeSpan.FromMilliseconds(3_000));
                    
                    sw.Stop();
                    _onWaitTimesReport?.Invoke(sw.ElapsedMilliseconds);
                    _onWorkTimesReport?.Invoke(0);
                }

                if (deliveredOrders > 0)
                {
                    _warehouse.NotifyFinishingForDeliveryman();
                    _logger.Log($"deliveryman {_name} delivered {deliveredOrders} orders.");
                }
                
                State = EmployeeState.Idle;
                
            } while (_thread.IsAlive);
        }
    }
}