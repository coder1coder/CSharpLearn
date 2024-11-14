using System;
using System.Collections.Concurrent;
using System.Linq;

namespace Threading.SynchronizationPrimitives
{
    public class DeliveryDepartment: IDepartment
    {
        private readonly ConcurrentStack<Deliveryman> _employees = new();
        private readonly Logger _logger;
        private readonly Warehouse _warehouse;
        
        private readonly ConcurrentBag<long> _requestAccessTimes = new();
        private readonly ConcurrentBag<long> _workTimes = new();
        private readonly ConcurrentBag<long> _waitWorkTimes = new();
        
        public DeliveryDepartment(Logger logger, Warehouse warehouse)
        {
            _logger = logger;
            _warehouse = warehouse;
        }
        
        public void AddEmployee()
        {
            var workDuration = new Random().Next(1_000, 3_001);
            
            var employeeName = $"{_employees.Count + 1}";
            var employee = new Deliveryman(
                name: employeeName, 
                workDuration: TimeSpan.FromMilliseconds(workDuration), 
                warehouse: _warehouse,
                logger: _logger,
                onAccessTimesReport: elapsedTime => _requestAccessTimes.Add(elapsedTime),
                onWaitTimesReport: elapsedTime => _waitWorkTimes.Add(elapsedTime),
                onWorkTimesReport: elapsedTime => _workTimes.Add(elapsedTime));

            _employees.Push(employee);
            employee.StartWork();
        }
        
        public void RemoveEmployee()
        {
            if (!_employees.TryPop(out _))
            {
                _logger.Log("No any deliverymen to remove");
            }
        }

        public void PrintInfo(IPrinter printer)
        {
            printer.Append($"Deliverymen: {_employees.Count}");

            var accessing = !_requestAccessTimes.IsEmpty ? _requestAccessTimes.Average() / 1_000 : 0;
            printer.Append($", Accessing {accessing:F}/s");

            var working = !_workTimes.IsEmpty ? _workTimes.Average() / 1_000 : 0;
            printer.Append($", Working {working:F}/s");

            var waiting = !_waitWorkTimes.IsEmpty ? _waitWorkTimes.Average() / 1_000 : 0;
            printer.Append($", Waiting {waiting:F}/s");
            
            printer.AppendLine();
            
            var gr = _employees
                .GroupBy(x => x.State)
                .ToDictionary(x=> x.Key, v=>v.Count());

            foreach (var state in Enum.GetValues<EmployeeState>())
            {
                gr.TryGetValue(state, out var count);

                switch (state)
                {
                    case EmployeeState.Idle:
                        printer.Append($"[color=Red|{state}]: {count}; ");
                        break;
                    case EmployeeState.Waiting:
                        printer.Append($"[color=Yellow|{state}]: {count}; ");
                        break;
                    case EmployeeState.Working:
                        printer.Append($"[color=Green|{state}]: {count}; ");
                        break;
                    default:
                        printer.Append($"{state}: {count}; ");
                        break;
                }
            }
            
            printer.AppendLine();

            foreach (var employee in _employees)
            {
                printer.Append($"[{employee.State.ToString()[..4]}]");
            }
        }
    }
}