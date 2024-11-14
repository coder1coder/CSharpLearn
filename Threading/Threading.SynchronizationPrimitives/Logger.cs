using System.Collections.Concurrent;

namespace Threading.SynchronizationPrimitives
{
    public class Logger
    {
        private readonly ConcurrentQueue<string> _log = new();
        
        public void Log(string message)
        {
            _log.Enqueue(message);
            if (_log.Count > 5)
            {
                _log.TryDequeue(out _);
            }
        }

        public void PrintMessages(IPrinter output)
        {
            foreach (var message in _log)
            {
                output.AppendLine(message);
            }
        }
    }
}