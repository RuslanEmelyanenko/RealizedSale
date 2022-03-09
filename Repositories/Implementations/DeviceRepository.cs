using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public Device GetDevice(string model)
        {
            var device = _dbContext.Devices.FirstOrDefault(d => d.Model == model);

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