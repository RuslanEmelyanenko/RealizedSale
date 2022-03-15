using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewProject_RealizedSale.Models;
using NewProject_RealizedSale.Repositories.Abstractions;

namespace NewProject_RealizedSale.Repositories
{
    public class DeviceTypeRepository : BaseRepository<DeviceType>, IDeviceTypeRepository
    {
        private readonly SaleContext _dbContext;

        public DeviceTypeRepository(SaleContext dbContext) 
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<DeviceType> GetByDeviceTypeAsync(string deviceType)
        {
            var type = await _dbContext.DeviceTypes.FirstOrDefaultAsync(d => d.Type == deviceType);

            return type;
        }
    }
}