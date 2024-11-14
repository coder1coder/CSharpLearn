namespace Patterns.Command
{
    public class CalculatorInvoker
    {
        private ICommand _lastCommand;
        
        private readonly CalculatorReceiver _calculatorReceiver;

        public CalculatorInvoker(CalculatorReceiver calculatorReceiver)
        {
            _calculatorReceiver = calculatorReceiver;
        }

        public void AddNumber(int number) => _lastCommand = new AddCommand(_calculatorReceiver, number);
        public void Undo() => _lastCommand?.Undo();
    }
}