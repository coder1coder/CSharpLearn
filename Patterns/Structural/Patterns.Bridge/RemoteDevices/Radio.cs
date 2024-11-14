using System;

namespace Patterns.Bridge.RemoteDevices
{
    public class Radio: RemoteDevice
    {
        public override void SetVolumeUp()
        {
            Console.WriteLine("Radio SetVolumeUp");
        }

        public override void SetVolumeDown()
        {
            Console.WriteLine("Radio SetVolumeDown");
        }

        public override void PowerOff()
        {
            Console.WriteLine("Radio PowerOff");
        }
    }
}