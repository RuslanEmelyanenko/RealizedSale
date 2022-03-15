using System.Collections.Generic;
using System.Threading.Tasks;
using NewProject_RealizedSale.Models;

namespace NewProject_RealizedSale.Repositories.Abstractions
{
    public interface IDeviceRepository : IBaseRepository<Device>
    {
        Task<Device> GetDeviceAsync(string model);

        Task<IList<Device>> GetAllDevicesAsync();
    }
}