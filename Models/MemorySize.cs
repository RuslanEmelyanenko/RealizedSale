using System.Collections.Generic;

namespace NewProject_RealizedSale.Models
{
    public class MemorySize : Entity
    {
        public int MemorySizeDevice { get; set; }

        public List<Device> Devices { get; set; }
    }
}
