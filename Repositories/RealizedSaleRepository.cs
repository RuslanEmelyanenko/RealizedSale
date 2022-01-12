using NewProject_RealizedSale.Models;

namespace NewProject_RealizedSale.Repositories
{
    public class RealizedSaleRepository : BaseRepository<RealizedSale>
    {
        public RealizedSaleRepository(SaleContext dbContext) 
            : base(dbContext)
        {
        }
    }
}
