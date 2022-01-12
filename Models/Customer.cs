using System.Collections.Generic;

namespace NewProject_RealizedSale.Models
{
    public class Customer : Entity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }

        public List<RealizedSale> RealizedSales { get; set; }
    }
}
