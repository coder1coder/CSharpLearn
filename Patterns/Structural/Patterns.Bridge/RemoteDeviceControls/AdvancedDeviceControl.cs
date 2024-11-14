using Patterns.Bridge.RemoteDevices;

namespace Patterns.Bridge.RemoteDeviceControls
{
    public class AdvancedDeviceControl: RemoteDeviceControl
    {
        private readonly RemoteDevice _device;
        
        public AdvancedDeviceControl(RemoteDevice device) : base(device)
        {
            _device = device;
        }

        public void PowerOff() => _device.PowerOff();
    }
}