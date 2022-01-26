using System.Collections.Generic;
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

        public RealizedSaleDto GetByRealizedSale(string date)
        {
            var realizedSale = _realizedSaleRepository.GetByRealizedSale(date);

            var realizedSaleDto = new RealizedSaleDto
            {
                Id = realizedSale.Id,
                Amount = realizedSale.Amount,
                Customer = realizedSale.Customer.Name,
                Date = realizedSale.Date,
                Device = realizedSale.Device.Model,
                TotalSum = realizedSale.TotalSum
            };

            return realizedSaleDto;
        }

        public IList<RealizedSaleDto> GetAllSales()
        {
            var realizedSale = _realizedSaleRepository.GetAllRealizedSale();

            var sales = new List<RealizedSaleDto>();

            foreach (var sale in sales)
            {
                var realizedSaleDto = new RealizedSaleDto
                {
                    Amount = sale.Amount,
                    Customer = sale.Customer,
                    Date = sale.Date,
                    Device = sale.Device,
                    TotalSum = sale.TotalSum
                };

                sales.Add(realizedSaleDto);
            }

            return sales;
        }

        public void CreateRealizedSale(RealizedSaleDto createRealizedSale)
        {
            var customer = _customerRepository.GetCustomerByNameAndSurname(createRealizedSale.Customer, createRealizedSale.Customer);
            var device = _deviceRepository.GetDevice(createRealizedSale.Device);

            if (customer == null) // Вот здесь у меня вопрос: правильно ли реализована проверка на наличие объекта CUSTOMER
            {
                customer = new Customer
                {
                    Name = createRealizedSale.Customer,
                    Surname = createRealizedSale.Customer,
                    PhoneNumber = createRealizedSale.Customer
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

        public void DeleteRealizedSale(string date)
        {
            var dateSale = _realizedSaleRepository.GetByRealizedSale(date);

            if (dateSale != null)
            {
                _realizedSaleRepository.Delete(dateSale);

                _realizedSaleRepository.Save();
            }
        }
    }
}