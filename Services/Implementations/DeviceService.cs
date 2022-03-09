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
        // 1 +
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
        // 2 Method isn't async
        public DeviceDto GetDevice(string model) // Get Device By Models.
        {
            var device = _deviceRepository.GetDevice(model);

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
        // 3 +
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
        // 4 Method isn't async
        public void CreateDevice(DeviceDto createDevice) // Create object.
        {
            var color = _colorRepository.GetByColorName(createDevice.Color);
            var memorySize = _memorySizeRepository.GetByMemorySize(createDevice.MemorySize);
            var deviceType = _deviceTypeRepository.GetByDeviceType(createDevice.DeviceType);

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
        // 5 Method isn't async
        public void UpdateDevice(UpdateDto updateDevice)
        {
            var color = _colorRepository.GetByColorName(updateDevice.Color);
            var memorySize = _memorySizeRepository.GetByMemorySize(updateDevice.MemorySize);
            var deviceType = _deviceTypeRepository.GetByDeviceType(updateDevice.DeviceType);

            var device = _deviceRepository.Get(updateDevice.Id);

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

        public void DeleteDevice(string model)
        {
            var device = _deviceRepository.GetDevice(model);

            if (device != null)
            {
                _deviceRepository.Delete(device);

                _deviceRepository.Save();
            }
        }
        // 6 +
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

            var sortedDevices = await GetSortedDevicesAsync(unsortedDevices, sortBy);

            return sortedDevices;
        }

        private async Task<IList<SortedDeviceDTO>> GetSortedDevicesAsync(IList<SortedDeviceDTO> unsortedDevices, string sortBy)
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
        // 7 +
        public async Task AddRangeDevicesAsync(IList<DeviceDto> deviceDtos)
        {
            var devices = await _deviceRepository.GetAllDevicesAsync();

            var newDevices = CreateDevices(deviceDtos);

            newDevices = newDevices.Except(devices, new DeviceEqualityComparer()).ToList();

            _deviceRepository.CreateRange(newDevices);

            _deviceRepository.Save();
        }
        // 7 Method isn't async
        private IList<Device> CreateDevices(IList<DeviceDto> deviceDtos)
        {
            var devices = new List<Device>();

            foreach (var deviceDto in deviceDtos)
            {
                var deviceType = _deviceTypeRepository.GetByDeviceType(deviceDto.DeviceType);
                var memorySize = _memorySizeRepository.GetByMemorySize(deviceDto.MemorySize);
                var color = _colorRepository.GetByColorName(deviceDto.Color);

                var deviceUpdate = _deviceRepository.Get(deviceDto.Id);

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