using System.Collections.Generic;

namespace NewProject_RealizedSale.Models
{
    public class Color : Entity
    {
        public string ColorDevice { get; set; }

        public List<Device> Devices { get; set; }
    }
}
