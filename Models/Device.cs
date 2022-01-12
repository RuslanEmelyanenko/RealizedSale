using System.Collections.Generic;

namespace NewProject_RealizedSale.Models
{
    public class Device : Entity
    {
        public string Model { get; set; }
        public double Price { get; set; }

        // ...
        public int ColorId { get; set; }
        public Color Color { get; set; }
        // ...
        public int MemorySizeId { get; set; }
        public MemorySize MemorySize { get; set; }
        // ...
        public int DeviceTypeId { get; set; }
        public DeviceType DeviceType { get; set; }
        // ...
        public List<RealizedSale> RealizedSales { get; set; }
    }
}
