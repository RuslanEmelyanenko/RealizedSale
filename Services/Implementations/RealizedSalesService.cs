using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewProject_RealizedSale.Dtos;
using NewProject_RealizedSale.Dtos.BaseDtos;
using NewProject_RealizedSale.Models;
using NewProject_RealizedSale.Repositories;
using NewProject_RealizedSale.Services.Abstractions;

namespace NewProject_RealizedSale.Services.Implementations
{
    class RealizedSalesService : IRealizedSalesService
    {
        private readonly RealizedSaleRepository _realizedSaleRepository;
        private readonly DeviceRepository _deviceRepository;
        private readonly CustomerRepository _customerRepository;

        public RealizedSalesService(RealizedSaleRepository realizedSaleRepository, 
            DeviceRepository deviceRepository,
            CustomerRepository customerRepository)
        {
            _realizedSaleRepository = realizedSaleRepository;
            _deviceRepository = deviceRepository;
            _customerRepository = customerRepository;
        }
        // 1 Method isn't async
        public RealizedSaleDto GetRealizedSaleByDate(string date)
        {
            var realizedSale = _realizedSaleRepository.GetByRealizedSale(date);

            var realizedSaleDto = new RealizedSaleDto
            {
                Id = realizedSale.Id,
                Amount = realizedSale.Amount,
                CustomerName = realizedSale.Customer.Name,
                CustomerSurname = realizedSale.Customer.Surname,
                CustomerPhoneNumber = realizedSale.Customer.PhoneNumber,
                Date = realizedSale.Date,
                DeviceModel = realizedSale.Device.Model,
                TotalSum = realizedSale.TotalSum
            };

            return realizedSaleDto;
        }
        // 2 +
        public async Task<IList<RealizedSaleDto>> GetAllSalesAsync()
        {
            var realizedSales = await _realizedSaleRepository.GetAllRealizedSaleAsync();

            var realizedSaleDto = new List<RealizedSaleDto>();

            foreach (var sale in realizedSales)
            {
                var realizedSaleItem = new RealizedSaleDto
                {
                    Amount = sale.Amount,
                    CustomerName = sale.Customer.Name,
                    CustomerSurname = sale.Customer.Surname,
                    CustomerPhoneNumber = sale.Customer.PhoneNumber,
                    Date = sale.Date,
                    DeviceModel = sale.Device.Model,
                    TotalSum = sale.TotalSum
                };

                realizedSaleDto.Add(realizedSaleItem);
            }

            return realizedSaleDto;
        }
        // 3 Method isn't async
        public void CreateRealizedSale(RealizedSaleDto createRealizedSale)
        {
            var customer = _customerRepository.GetCustomerByNameAndSurname(createRealizedSale.CustomerName, createRealizedSale.CustomerSurname);
            var device = _deviceRepository.GetDevice(createRealizedSale.DeviceModel);

            if (customer == null)
            {
                customer = new Customer
                {
                    Name = createRealizedSale.CustomerName,
                    Surname = createRealizedSale.CustomerSurname,
                    PhoneNumber = createRealizedSale.CustomerPhoneNumber
                };
            }

            var realizedSale = new RealizedSale
            {
                Amount = createRealizedSale.Amount,
                Customer = customer,
                Date = createRealizedSale.Date,
                Device = device,
                //TotalSum = createRealizedSale.TotalSum
            };

            _realizedSaleRepository.Create(realizedSale);

            _realizedSaleRepository.Save();
        }
        // 4 Method isn't async
        public void DeleteRealizedSale(string date)
        {
            var dateSale = _realizedSaleRepository.GetByRealizedSale(date);

            if (dateSale != null)
            {
                _realizedSaleRepository.Delete(dateSale);

                _realizedSaleRepository.Save();
            }
        }
        // 5 +
        public async Task<IList<CounterOfPurchasedDevicesDto>> GetNumberOfDevicesSoldByModel()
        {
            var countRealizedSaleDevises = await _realizedSaleRepository.GetAllRealizedSaleAsync();

            var grupByModelRealizedSale = countRealizedSaleDevises
                .GroupBy(r => r.Device.Model)
                .Select(g => new CounterOfPurchasedDevicesDto()
                {
                    Model = g.Key,
                    CounterOfPurchasedDevices = g.Count()
                })
                .ToList();

            return grupByModelRealizedSale;
        }
    }
}