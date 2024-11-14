using Patterns.Bridge.RemoteDevices;

namespace Patterns.Bridge.RemoteDeviceControls
{
    public class DefaultDeviceControl: RemoteDeviceControl
    {
        public DefaultDeviceControl(RemoteDevice device) : base(device)
        {
        }
    }
}