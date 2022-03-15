using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewProject_RealizedSale.Models;
using NewProject_RealizedSale.Repositories.Abstractions;

namespace NewProject_RealizedSale.Repositories
{
    public class DeviceRepository : BaseRepository<Device>, IDeviceRepository
    {
        private readonly SaleContext _dbContext;
        
        public DeviceRepository(SaleContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Device> GetDeviceAsync(string model)
        {
            var device = await _dbContext.Devices.FirstOrDefaultAsync(d => d.Model == model);

            return device;
        }

        public async Task<IList<Device>> GetAllDevicesAsync()
        {
            var devices = await _dbContext.Devices
                .Include(d => d.Color)
                .Include(d => d.MemorySize)
                .Include(d => d.DeviceType)
                .ToListAsync();

            return devices;
        }
    }
}