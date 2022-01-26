namespace NewProject_RealizedSale.Dtos.BaseDtos
{
    public class RealizedSaleDto
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public double TotalSum { get; set; }
        public string Date { get; set; }
        public string Device { get; set; }
        public string Customer { get; set; }
    }
}