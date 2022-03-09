using System.Collections.Generic;
using NewProject_RealizedSale.Models;

namespace NewProject_RealizedSale.EqualityComparer
{
    public class DeviceEqualityComparer : IEqualityComparer<Device>
    {
        public bool Equals(Device firstDevice, Device secondDevice)
        {
            if (firstDevice == null && secondDevice == null)
            {
                return true;
            }
            else if (firstDevice == null || secondDevice == null)
            {
                return false;
            }
            else if (firstDevice.DeviceType.Type == secondDevice.DeviceType.Type
                     && firstDevice.Model == secondDevice.Model
                     && firstDevice.Color.ColorDevice == secondDevice.Color.ColorDevice
                     && firstDevice.MemorySize.MemorySizeDevice == secondDevice.MemorySize.MemorySizeDevice
                     && firstDevice.Price == secondDevice.Price)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetHashCode(Device device)
        {
            int hCode = device.DeviceType.Type.GetHashCode()
                        ^ device.Model.GetHashCode()
                        ^ device.Color.ColorDevice.GetHashCode()
                        ^ device.MemorySize.MemorySizeDevice.GetHashCode()
                        ^ device.Price.GetHashCode();
            return hCode.GetHashCode();
        }
    }
}