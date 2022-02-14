namespace NewProject_RealizedSale.Dtos.BaseDtos
{
    public class RealizedSaleDto
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public double TotalSum { get; set; }
        public string Date { get; set; }
        public string DeviceModel { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string CustomerPhoneNumber { get; set; }
    }
}