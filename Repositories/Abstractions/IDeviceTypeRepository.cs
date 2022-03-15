using System.Threading.Tasks;
using NewProject_RealizedSale.Models;

namespace NewProject_RealizedSale.Repositories.Abstractions
{
    interface IDeviceTypeRepository : IBaseRepository<DeviceType>
    {
        Task<DeviceType> GetByDeviceTypeAsync(string deviceType);
    }
}