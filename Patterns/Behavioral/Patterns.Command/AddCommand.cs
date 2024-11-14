namespace Patterns.Command
{
    public class AddCommand: Command
    {
        private readonly CalculatorReceiver _calculatorReceiver;
        private readonly int _number;
        
        public AddCommand(CalculatorReceiver calculatorReceiver, int number)
        {
            _calculatorReceiver = calculatorReceiver;
            _number = number;
        }
        
        public override void Execute()
        {
            _calculatorReceiver.Add(_number);
        }

        public override void Undo()
        {
        }
    }
}