using NewProject_RealizedSale.DTOs;
using System.Collections.Generic;
using NewProject_RealizedSale.Dtos.DropdownDto;

namespace NewProject_RealizedSale.Services.Abstractions
{
    public interface IDeviceService
    {
        IList<SortedDeviceDTO> GetSorted(string sortBy);
        IList<DeviceDropdownDto> GetDeviceDropdown();
    }
}