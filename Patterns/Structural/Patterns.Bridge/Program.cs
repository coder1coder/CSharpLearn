using System;
using System.Collections.Generic;
using Patterns.Bridge.RemoteDeviceControls;
using Patterns.Bridge.RemoteDevices;

namespace Patterns.Bridge
{
    class Program
    {
        /// <summary>
        /// Мост — это структурный паттерн проектирования,
        /// который разделяет один или несколько классов на две отдельные иерархии — абстракцию и реализацию,
        /// позволяя изменять их независимо друг от друга.
        /// </summary>
        static void Main(string[] _)
        {
            var devices = new List<RemoteDevice>
            {
                new Tv(),
                new Radio()
            };

            foreach (var remoteDevice in devices)
            {
                Console.WriteLine($"Current device is {remoteDevice.GetType().Name}");
                
                var defaultControl = new DefaultDeviceControl(remoteDevice);
                defaultControl.SetVolumeUp();
                defaultControl.SetVolumeDown();
                
                var advancedControl = new AdvancedDeviceControl(remoteDevice);
                advancedControl.PowerOff();
            }
        }
    }
}