using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Threading.SynchronizationPrimitives
{
    public class OperatorManagement
    {
        private readonly Logger _logger;
        private readonly Stack<Operator> _operators = new();
        private readonly Warehouse _warehouse;
        
        private readonly ConcurrentBag<long> _requestAccessTimes = new();
        private readonly ConcurrentBag<long> _workTimes = new();
        private readonly ConcurrentBag<long> _waitWorkTimes = new();
        
        public OperatorManagement(Logger logger, Warehouse warehouse)
        {
            _logger = logger;
            _warehouse = warehouse;
        }
        
        public void AddWorker()
        {
            var workDuration = new Random().Next(1_000, 3_001);
            
            var operatorName = $"{_operators.Count + 1}";
            var @operator = new Operator(
                name: operatorName, 
                workDuration: TimeSpan.FromMilliseconds(workDuration), 
                warehouse: _warehouse,
                logger: _logger,
                onAccessTimesReport: elapsedTime => _requestAccessTimes.Add(elapsedTime),
                onWaitTimesReport: elapsedTime => _waitWorkTimes.Add(elapsedTime),
                onWorkTimesReport: elapsedTime => _workTimes.Add(elapsedTime));

            _operators.Push(@operator);
            _logger.Log($"operator #{operatorName} added");
            @operator.StartWork();
        }

        public void RemoveWorker()
        {
            if (_operators.TryPop(out var worker))
            {
                _logger.Log($"operator #{worker.Name} was removed");    
            }
            else
            {
                _logger.Log("No any worker to remove");
            }
        }

        public void PrintInfo(StringBuilder output)
        {
            output.Append($"Operators: {_operators.Count}");

            var accessing = !_requestAccessTimes.IsEmpty ? _requestAccessTimes.Average() / 1_000 : 0;
            output.Append($", Accessing {accessing:F}/s");

            var working = !_workTimes.IsEmpty ? _workTimes.Average() / 1_000 : 0;
            output.Append($", Working {working:F}/s");

            var waiting = !_waitWorkTimes.IsEmpty ? _waitWorkTimes.Average() / 1_000 : 0;
            output.Append($", Waiting {waiting:F}/s");

            output.AppendLine();
        }
    }
}