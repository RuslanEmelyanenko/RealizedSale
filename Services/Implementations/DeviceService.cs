using System.Collections.Generic;
using System.Linq;
using NewProject_RealizedSale.DTOs;
using NewProject_RealizedSale.Dtos.CreateUpdate;
using NewProject_RealizedSale.Dtos.DropdownDto;
using NewProject_RealizedSale.Models;
using NewProject_RealizedSale.Repositories;
using NewProject_RealizedSale.Services.Abstractions;

namespace NewProject_RealizedSale.Services.Implementations
{
    public class DeviceService : IDeviceService
    {
        private readonly DeviceRepository _deviceRepository;
        private readonly ColorRepository _colorRepository;
        private readonly MemorySizeRepository _memorySizeRepository;

        public DeviceService(DeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        public IList<DeviceDropdownDto> GetDeviceDropdown() // Creating a dropdown list of devices.
        {
            var devices = _deviceRepository.GetAll();

            var devicesDropdown = new List<DeviceDropdownDto>();

            foreach (var device in devices)
            {
                var deviceDropdownItem = new DeviceDropdownDto
                {
                    Id = device.Id,
                    DeviceModel = device.Model
                };

                devicesDropdown.Add(deviceDropdownItem);
            }

            return devicesDropdown;
        }

        public DeviceUpdateDto GetDeviceByModel(string model) // Get Device By Models.
        {
            var device = _deviceRepository.GetByDeviceModel(model);

            var deviceDto = new DeviceUpdateDto
            {
                Id = device.Id,
                Model = device.Model,
                Price = device.Price,
                Color = device.Color.ColorDevice,
                MemorySize = device.MemorySize.MemorySizeDevice
            };

            return deviceDto;
        }

        public void Create(DeviceUpdateDto createDevice)  // Create object.
        {
            var color = _colorRepository.GetByColorName(createDevice.Color);
            var memorySize = _memorySizeRepository.GetByMemorySize(createDevice.MemorySize);

            var device = new Device
            {
                Model = createDevice.Model,
                Price = createDevice.Price,
                Color = color,
                MemorySize = memorySize
            };
        }

        public void UpdateDevice(DeviceUpdateDto updateDevice)
        {
            var device = _deviceRepository.Get(updateDevice.Id);

            device.Model = updateDevice.Model;
            device.Price = updateDevice.Price;
            device.Color.ColorDevice = updateDevice.Color;
            device.MemorySize.MemorySizeDevice = updateDevice.MemorySize;
        }
        
        public IList<SortedDeviceDTO> GetSortedDevices(string sortBy) // Sorting devices by: model, price and memory size.
        {
            var devices = _deviceRepository.GetAll();
  
            var unsortedDevices = new List<SortedDeviceDTO>();

            foreach (var device in devices)
            {
                var unsortedDevice = new SortedDeviceDTO
                {
                    Model = device.Model,
                    Price = device.Price,
                    Color = device.Color.ColorDevice,
                    MemorySize = device.MemorySize.MemorySizeDevice
                };

                unsortedDevices.Add(unsortedDevice);
            }

            var sortedDevices = GetSortedDevices(unsortedDevices, sortBy);

            return sortedDevices;
        }

        private IList<SortedDeviceDTO> GetSortedDevices(IList<SortedDeviceDTO> unsortedDevices, string sortBy)
        {
            var sortedDevices = new List<SortedDeviceDTO>();

            if (sortBy == "model")
            {
                sortedDevices = unsortedDevices.OrderBy(d => d.Model).ToList();
            }
            else if (sortBy == "price")
            {
                sortedDevices = unsortedDevices.OrderBy(d => d.Price).ToList();
            }
            else if (sortBy == "memorySize")
            {
                sortedDevices = unsortedDevices.OrderBy(d => d.MemorySize).ToList();
            }

            return sortedDevices;
        }
    }
}