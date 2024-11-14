using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Threading.SynchronizationPrimitives
{
    public class OperatorDepartment: IDepartment
    {
        private readonly Logger _logger;
        private readonly Stack<Operator> _employees = new();
        private readonly Warehouse _warehouse;
        
        private readonly ConcurrentBag<long> _requestAccessTimes = new();
        private readonly ConcurrentBag<long> _workTimes = new();
        private readonly ConcurrentBag<long> _waitWorkTimes = new();
        
        public OperatorDepartment(Logger logger, Warehouse warehouse)
        {
            _logger = logger;
            _warehouse = warehouse;
        }
        
        public void AddEmployee()
        {
            var workDuration = new Random().Next(1_000, 3_001);
            
            var operatorName = $"{_employees.Count + 1}";
            var @operator = new Operator(
                name: operatorName, 
                workDuration: TimeSpan.FromMilliseconds(workDuration), 
                warehouse: _warehouse,
                logger: _logger,
                onAccessTimesReport: elapsedTime => _requestAccessTimes.Add(elapsedTime),
                onWaitTimesReport: elapsedTime => _waitWorkTimes.Add(elapsedTime),
                onWorkTimesReport: elapsedTime => _workTimes.Add(elapsedTime));

            _employees.Push(@operator);
            @operator.StartWork();
        }

        public void RemoveEmployee()
        {
            if (!_employees.TryPop(out _))
            {
                _logger.Log("No any worker to remove");
            }
        }

        public void PrintInfo(IPrinter output)
        {
            output.Append($"Operators: {_employees.Count}");

            var accessing = !_requestAccessTimes.IsEmpty ? _requestAccessTimes.Average() / 1_000 : 0;
            output.Append($", Accessing {accessing:F}/s");

            var working = !_workTimes.IsEmpty ? _workTimes.Average() / 1_000 : 0;
            output.Append($", Working {working:F}/s");

            var waiting = !_waitWorkTimes.IsEmpty ? _waitWorkTimes.Average() / 1_000 : 0;
            output.Append($", Waiting {waiting:F}/s");
            
            output.AppendLine();
            
            var gr = _employees
                .GroupBy(x => x.State)
                .ToDictionary(x=> x.Key, v=>v.Count());

            foreach (var state in Enum.GetValues<EmployeeState>())
            {
                gr.TryGetValue(state, out var count);

                switch (state)
                {
                    case EmployeeState.Idle:
                        output.Append($"[color=Red|{state}]: {count}; ");
                        break;
                    case EmployeeState.Waiting:
                        output.Append($"[color=Yellow|{state}]: {count}; ");
                        break;
                    case EmployeeState.Working:
                        output.Append($"[color=Green|{state}]: {count}; ");
                        break;
                    default:
                        output.Append($"{state}: {count}; ");
                        break;
                }
            }

            output.AppendLine();
        }
    }
}