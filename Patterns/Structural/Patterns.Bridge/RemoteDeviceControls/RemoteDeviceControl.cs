using Patterns.Bridge.RemoteDevices;

namespace Patterns.Bridge.RemoteDeviceControls
{
    public abstract class RemoteDeviceControl
    {
        private readonly RemoteDevice _device;

        protected RemoteDeviceControl(RemoteDevice device)
        {
            _device = device;
        }

        public void SetVolumeUp() => _device.SetVolumeUp();
        public void SetVolumeDown() => _device.SetVolumeDown();
    }
}