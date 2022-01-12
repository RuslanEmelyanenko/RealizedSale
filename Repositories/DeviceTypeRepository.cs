using NewProject_RealizedSale.Models;

namespace NewProject_RealizedSale.Repositories
{
    public class DeviceTypeRepository : BaseRepository<DeviceType>
    {
        public DeviceTypeRepository(SaleContext dbContext) 
            : base(dbContext)
        {
        }
    }
}
