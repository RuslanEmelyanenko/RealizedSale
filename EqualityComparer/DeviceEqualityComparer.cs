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
            else if (firstDevice.DeviceType == secondDevice.DeviceType 
                     && firstDevice.Model == secondDevice.Model
                     && firstDevice.Color == secondDevice.Color
                     && firstDevice.MemorySize == secondDevice.MemorySize
                     && firstDevice.Price == secondDevice.Price
                     )
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
            int hCode = device.DeviceType.GetHashCode()
                        ^ device.Model.GetHashCode()
                        ^ device.Color.GetHashCode()
                        ^ device.MemorySize.MemorySizeDevice.GetHashCode()
                        ^ device.Price.GetHashCode();
            return hCode.GetHashCode();
        }
    }
}