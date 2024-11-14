namespace Patterns.Command
{
    class Program
    {
        /// <summary>
        /// Команда — это поведенческий паттерн проектирования, который превращает запросы в объекты,
        /// позволяя передавать их как аргументы при вызове методов, ставить запросы в очередь, логировать их,
        /// а также поддерживать отмену операций.
        /// </summary>
        static void Main(string[] _)
        {
            var calculatorReceiver = new CalculatorReceiver();
            var calculatorInvoker = new CalculatorInvoker(calculatorReceiver);
            calculatorInvoker.AddNumber(5);
            calculatorInvoker.Undo();
        }
    }
}