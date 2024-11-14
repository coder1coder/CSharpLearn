using System;

namespace Patterns.Bridge.RemoteDevices
{
    public class Tv: RemoteDevice
    {
        public override void SetVolumeUp()
        {
            Console.WriteLine("TV SetVolumeUp");
        }

        public override void SetVolumeDown()
        {
            Console.WriteLine("TV SetVolumeDown");
        }

        public override void PowerOff()
        {
            Console.WriteLine("TV PowerOff");
        }
    }
}