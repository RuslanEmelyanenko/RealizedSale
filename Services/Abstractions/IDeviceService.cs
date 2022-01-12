using NewProject_RealizedSale.DTOs;
using System.Collections.Generic;
using NewProject_RealizedSale.Dtos.DropdownDto;

namespace NewProject_RealizedSale.Services.Abstractions
{
    interface IDeviceService
    {
        IList<SortedDeviceDTO> GetSortedDevices(string sortBy);
        IList<DeviceDropdownDto> GetDeviceDropdown();
    }
}
