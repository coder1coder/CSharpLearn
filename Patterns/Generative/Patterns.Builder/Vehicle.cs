using System;
using System.Collections.Generic;

namespace Patterns.Builder
{
    internal class Vehicle
    {
        private readonly string _vehicleType;
        private readonly Dictionary<string,string> _parts;
        private string frame;
        private int enginePower;
        private int wheelsPower;
        private int doorsCount;

        public Vehicle(string vehicleType)
        {
            _vehicleType = vehicleType;
        }

        public string Frame { set { frame = value; } }
        public int EnginePower { set { enginePower = value; } }
        public int WheelsDiameter { set { wheelsPower = value; } }
        public int DoorsCount { set { doorsCount = value; } }

        public void Show()
        {
            Console.WriteLine($"Тип транспортного средства: {_vehicleType}");
            Console.WriteLine($" Рама:  {frame}");
            Console.WriteLine($" Двигатель: {enginePower} лошадиных сил");
            Console.WriteLine($" Колеса: {wheelsPower} дюймов");
            Console.WriteLine($" Количество дверей:  {doorsCount}");
        }
    }
}