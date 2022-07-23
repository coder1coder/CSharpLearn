using System;

namespace Patterns.Builder
{
    internal class Vehicle
    {
        private readonly string _vehicleType;
        private string _frame;
        private int _enginePower;
        private int _wheelsPower;
        private int _doorsCount;

        public Vehicle(string vehicleType)
        {
            _vehicleType = vehicleType;
        }

        public string Frame { set => _frame = value; }
        public int EnginePower { set => _enginePower = value; }
        public int WheelsDiameter { set => _wheelsPower = value; }
        public int DoorsCount { set => _doorsCount = value; }

        public void Show()
        {
            Console.WriteLine($"Тип транспортного средства: {_vehicleType}");
            Console.WriteLine($" Рама:  {_frame}");
            Console.WriteLine($" Двигатель: {_enginePower} лошадиных сил");
            Console.WriteLine($" Колеса: {_wheelsPower} дюймов");
            Console.WriteLine($" Количество дверей:  {_doorsCount}");
        }
    }
}