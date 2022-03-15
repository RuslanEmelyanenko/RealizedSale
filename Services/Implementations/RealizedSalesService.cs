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
       
        public async Task<RealizedSaleDto> GetRealizedSaleByDateAsync(string date)
        {
            var realizedSale = await _realizedSaleRepository.GetByRealizedSaleAsync(date);

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
        
        public async Task CreateRealizedSaleAsync(RealizedSaleDto createRealizedSale)
        {
            var customer = await _customerRepository.GetCustomerByNameAndSurnameAsync(createRealizedSale.CustomerName, createRealizedSale.CustomerSurname);
            var device = await _deviceRepository.GetDeviceAsync(createRealizedSale.DeviceModel);

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
       
        public async Task DeleteRealizedSaleAsync(string date)
        {
            var dateSale = await _realizedSaleRepository.GetByRealizedSaleAsync(date);

            if (dateSale != null)
            {
                _realizedSaleRepository.Delete(dateSale);

                _realizedSaleRepository.Save();
            }
        }
        
        public async Task<IList<CounterOfPurchasedDevicesDto>> GetNumberOfDevicesSoldByModelAsync()
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