using System;

namespace Patterns.Command
{
    public class CalculatorReceiver
    {
        private int _sum = 0;

        public void Add(int number)
        {
            Console.WriteLine("Called receiver action: add");
            _sum += number;
        }

        public void SubStruct(int number)
        {
            Console.WriteLine("Called receiver action: substract");
            _sum -= number;
        }
    }
}