using System.Linq;
using NewProject_RealizedSale.Models;

namespace NewProject_RealizedSale.Repositories
{
    public class DeviceTypeRepository : BaseRepository<DeviceType>
    {
        private readonly SaleContext _dbContext;

        public DeviceTypeRepository(SaleContext dbContext) 
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public DeviceType GetByDeviceType(string deviceType)
        {
            var type = _dbContext.DeviceTypes.FirstOrDefault(d => d.Type == deviceType);

            return type;
        }
    }
}