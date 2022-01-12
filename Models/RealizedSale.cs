namespace NewProject_RealizedSale.Models
{
    public class RealizedSale : Entity
    {
        public int Amount { get; set; }
        public double TotalSum { get; set; }
        public string Date { get; set; }
        // ...
        public int DeviceId { get; set; }
        public Device Device { get; set; }
        // ...
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
