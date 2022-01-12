using System.Collections.Generic;

namespace NewProject_RealizedSale.Models
{
    public class DeviceType : Entity
    {
        public string Type { get; set; }

        public List<Device> Devices { get; set; }
    }
}
