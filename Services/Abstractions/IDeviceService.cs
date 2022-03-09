using NewProject_RealizedSale.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewProject_RealizedSale.Dtos.BaseDtos;
using NewProject_RealizedSale.Dtos.DropdownDto;

namespace NewProject_RealizedSale.Services.Abstractions
{
    public interface IDeviceService
    {
        Task<IList<SortedDeviceDTO>> GetSortedAsync(string sortBy);
        Task<IList<DeviceDropdownDto>> GetDeviceDropdownAsync();
        Task<IList<DeviceDto>> GetAllDevicesAsync();
    }
}