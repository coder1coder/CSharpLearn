namespace Patterns.Bridge.RemoteDevices
{
    public abstract class RemoteDevice
    {
        public abstract void SetVolumeUp();
        public abstract void SetVolumeDown();
        public abstract void PowerOff();
    }
}