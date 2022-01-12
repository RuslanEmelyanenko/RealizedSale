using System.Linq;
using NewProject_RealizedSale.Models;

namespace NewProject_RealizedSale.Repositories
{
    public class DeviceRepository : BaseRepository<Device>
    {
        private readonly SaleContext _dbContext;
        
        public DeviceRepository(SaleContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Device GetByDeviceModel(string model)
        {
            var device = DbContext.Devices.FirstOrDefault(d => d.Model == model);

            return device;
        }
    }
}