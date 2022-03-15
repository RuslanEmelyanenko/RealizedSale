using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewProject_RealizedSale.DTOs;
using NewProject_RealizedSale.Dtos.BaseDtos;
using NewProject_RealizedSale.Dtos.CreateUpdate;
using NewProject_RealizedSale.Dtos.DropdownDto;
using NewProject_RealizedSale.EqualityComparer;
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
        private readonly DeviceTypeRepository _deviceTypeRepository;

        public DeviceService(DeviceRepository deviceRepository, ColorRepository colorRepository,
            MemorySizeRepository memorySizeRepository, DeviceTypeRepository deviceTypeRepository)
        {
            _deviceRepository = deviceRepository;
            _colorRepository = colorRepository;
            _memorySizeRepository = memorySizeRepository;
            _deviceTypeRepository = deviceTypeRepository;
        }
        
        public async Task<IList<DeviceDropdownDto>> GetDeviceDropdownAsync() // Creating a dropdown list of devices.
        {
            var devices =  await _deviceRepository.GetAllAsync();

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
        
        public async Task<DeviceDto> GetDeviceAsync(string model) // Get Device By Models.
        {
            var device = await _deviceRepository.GetDeviceAsync(model);

            var deviceDto = new DeviceDto()
            {
                Id = device.Id,
                Model = device.Model,
                Price = device.Price,
                Color = device.Color.ColorDevice,
                MemorySize = device.MemorySize.MemorySizeDevice,
                DeviceType = device.DeviceType.Type
            };

            return deviceDto;
        }
        
        public async Task<IList<DeviceDto>> GetAllDevicesAsync() // Get All Devices (Method Read)
        {
            var devices = await _deviceRepository.GetAllDevicesAsync();
            var deviceDto = new List<DeviceDto>();

            foreach (var device in devices)
            {
                var deviceItem = new DeviceDto
                {
                    Id = device.Id,
                    Model = device.Model,
                    Price = device.Price,
                    Color = device.Color.ColorDevice,
                    MemorySize = device.MemorySize.MemorySizeDevice,
                    DeviceType = device.DeviceType.Type
                };

                deviceDto.Add(deviceItem);
            }

            return deviceDto;
        }
        
        public async Task CreateDeviceAsync(DeviceDto createDevice) // Create object.
        {
            var color = await _colorRepository.GetByColorNameAsync(createDevice.Color);
            var memorySize = await _memorySizeRepository.GetByMemorySizeAsync(createDevice.MemorySize);
            var deviceType = await _deviceTypeRepository.GetByDeviceTypeAsync(createDevice.DeviceType);

            if (color == null)
            {
                color = new Color
                {
                    ColorDevice = createDevice.Color
                };
            }

            if (memorySize == null)
            {
                memorySize = new MemorySize
                {
                    MemorySizeDevice = createDevice.MemorySize
                };
            }

            if (deviceType == null)
            {
                deviceType = new DeviceType
                {
                    Type = createDevice.DeviceType
                };
            }

            var device = new Device
            {
                Model = createDevice.Model,
                Price = createDevice.Price,
                Color = color,
                MemorySize = memorySize,
                DeviceType = deviceType
            };

            _deviceRepository.Create(device);

            _deviceRepository.Save();
        }
        
        public async Task UpdateDeviceAsync(UpdateDto updateDevice)
        {
            var color = await _colorRepository.GetByColorNameAsync(updateDevice.Color);
            var memorySize = await _memorySizeRepository.GetByMemorySizeAsync(updateDevice.MemorySize);
            var deviceType = await _deviceTypeRepository.GetByDeviceTypeAsync(updateDevice.DeviceType);

            var device = await _deviceRepository.GetAsync(updateDevice.Id);

            if (color == null)
            {
                color = new Color
                {
                    ColorDevice = updateDevice.Color
                };
            }

            if (memorySize == null)
            {
                memorySize = new MemorySize
                {
                    MemorySizeDevice = updateDevice.MemorySize
                };
            }

            if (deviceType == null)
            {
                deviceType = new DeviceType
                {
                    Type = updateDevice.DeviceType
                };
            }

            device.Color = color;
            device.MemorySize = memorySize;
            device.DeviceType = deviceType;
            device.Model = updateDevice.Model;
            device.Price = updateDevice.Price;

            _deviceRepository.Save();
        }

        public async Task DeleteDeviceAsync(string model)
        {
            var device = await _deviceRepository.GetDeviceAsync(model);

            if (device != null)
            {
                _deviceRepository.Delete(device);

                _deviceRepository.Save();
            }
        }
        
        public async Task<IList<SortedDeviceDTO>> GetSortedAsync(string sortBy) // Sorting devices by: model, price and memory size.
        {
            var devices = await _deviceRepository.GetAllDevicesAsync();

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
            if (sortBy == "model")
            {
                unsortedDevices = unsortedDevices.OrderBy(d => d.Model).ToList();
            }
            else if (sortBy == "price")
            {
                unsortedDevices = unsortedDevices.OrderBy(d => d.Price).ToList();
            }
            else if (sortBy == "memorySize")
            {
                unsortedDevices = unsortedDevices.OrderBy(d => d.MemorySize).ToList();
            }

            return unsortedDevices;
        }
        
        public async Task AddRangeDevicesAsync(IList<DeviceDto> deviceDtos)
        {
            var devices = await _deviceRepository.GetAllDevicesAsync();

            var newDevices = await CreateDevicesAsync(deviceDtos);

            newDevices = newDevices.Except(devices, new DeviceEqualityComparer()).ToList();

            _deviceRepository.CreateRange(newDevices);

            _deviceRepository.Save();
        }
        
        private async Task<IList<Device>> CreateDevicesAsync(IList<DeviceDto> deviceDtos)
        {
            var devices = new List<Device>();

            foreach (var deviceDto in deviceDtos)
            {
                var deviceType = await _deviceTypeRepository.GetByDeviceTypeAsync(deviceDto.DeviceType);
                var memorySize = await _memorySizeRepository.GetByMemorySizeAsync(deviceDto.MemorySize);
                var color = await _colorRepository.GetByColorNameAsync(deviceDto.Color);

                var deviceUpdate = _deviceRepository.GetAsync(deviceDto.Id);

                if (color == null)
                {
                    color = new Color
                    {
                        ColorDevice = deviceDto.Color
                    };
                }

                if (memorySize == null)
                {
                    memorySize = new MemorySize
                    {
                        MemorySizeDevice = deviceDto.MemorySize
                    };
                }

                if (deviceType == null)
                {
                    deviceType = new DeviceType
                    {
                        Type = deviceDto.DeviceType
                    };
                }

                var device = new Device
                {
                    DeviceType = deviceType,
                    Model = deviceDto.Model,
                    Color = color,
                    MemorySize = memorySize,
                    Price = deviceDto.Price
                };

                devices.Add(device);
            }

            return devices;
        }
    }
}