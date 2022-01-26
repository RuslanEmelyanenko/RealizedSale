using System;
using System.Collections.Generic;
using NewProject_RealizedSale.Dtos.BaseDtos;
using NewProject_RealizedSale.Models;
using NewProject_RealizedSale.Repositories;
using NewProject_RealizedSale.Services.Implementations;

namespace NewProject_RealizedSale
{
    public class Program
    {
        static void Main(string[] args)
        {
            var dbContext = new SaleContext();

            var colorRepository = new ColorRepository(dbContext);
            var memorySizeRepository = new MemorySizeRepository(dbContext);
            var deviceTypeRepository = new DeviceTypeRepository(dbContext);
            var customerRepository = new CustomerRepository(dbContext);

            var deviceRepository = new DeviceRepository(dbContext);
            var deviceService = new DeviceService(deviceRepository, colorRepository, memorySizeRepository, deviceTypeRepository);

            //var customerService = new CustomerService(customerRepository); // - Так как Customer создается через продажу девайса, эта запись будет лишней

            var realizedSaleRepository = new RealizedSaleRepository(dbContext);
            var realizedSaleService = new RealizedSalesService(realizedSaleRepository, deviceRepository, customerRepository);

            var phoneSe64 = new DeviceDto
            {
                Model = "iPhone SE",
                Price = 1299.0,
                Color = "Black",
                MemorySize = 64,
                DeviceType = "Phone"
            };
            var phoneSe128 = new DeviceDto
            {
                Model = "iPhone SE",
                Price = 1499.0,
                Color = "White",
                MemorySize = 128,
                DeviceType = "Phone"
            };
            var phoneSe256 = new DeviceDto
            {
                Model = "iPhone SE",
                Price = 2099.0,
                Color = "Space Gray",
                MemorySize = 256,
                DeviceType = "Phone"
            };
            var phone11_64 = new DeviceDto()
            {
                Model = "iPhone 11",
                Price = 1999.0,
                Color = "Green",
                MemorySize = 64,
                DeviceType = "Phone"
            };
            var phone11_128 = new DeviceDto
            {
                Model = "iPhone 11",
                Price = 2199.0,
                Color = "White",
                MemorySize = 128,
                DeviceType = "Phone"
            };
            var phoneXr64 = new DeviceDto
            {
                Model = "iPhone XR",
                Price = 1899.0,
                Color = "White",
                MemorySize = 64,
                DeviceType = "Phone"
            };
            var phoneXr128 = new DeviceDto
            {
                Model = "iPhone XR",
                Price = 2099.0,
                Color = "Gold",
                MemorySize = 128,
                DeviceType = "Phone"
            };
            var phone12mini128 = new DeviceDto
            {
                Model = "iPhone 12 mini",
                Price = 2499.0,
                Color = "White",
                MemorySize = 128,
                DeviceType = "Phone"
            };
            var phone12mini256 = new DeviceDto
            {
                Model = "iPhone 12 mini",
                Price = 3199.0,
                Color = "Gold",
                MemorySize = 256,
                DeviceType = "Phone"
            };

            var iPhones = new List<DeviceDto>
            {
                phoneSe64, phoneSe128, phoneSe256, phone11_64, phone11_128, phoneXr64, phoneXr128, phone12mini128, phone12mini256
            };

            foreach (var iPhone in iPhones)
            {
                //deviceService.CreateDevice(iPhone);
            }
                                                // Создание покупателя здесь нужно убрать. 
                                                // Customer создается через продажи (так как цвет, память, тип у device)
                                                // Cestomers можно удалить
            var customer1 = new CustomerDto
            {
                Name = "Ruslan",
                Surname = "Emelyanenk",
                PhoneNumber = "+375 33 0000000"
            };
            var customer2 = new CustomerDto
            {
                Name = "Stanislav",
                Surname = "Ignatenko",
                PhoneNumber = "+375 29 0000000"
            };
            var customer3 = new CustomerDto
            {
                Name = "Anna",
                Surname = "Khalikova",
                PhoneNumber = "+375 25 0000000"
            };

            var customers = new List<CustomerDto>
            {
                customer1, customer2, customer3
            };

            foreach (var customer in customers)
            {
                //customerService.CreateCustomer(customer);
            }

            //deviceService.DeleteDevice("iPhone SE");  // Метод работает!!!

            //Сортировка девайсов
            var sortedDevices = deviceService.GetSorted("model"); // Метод работает!!!

            Console.WriteLine("\nОтсортированный список девайсов: \n");
            foreach (var device in sortedDevices)
            {
                Console.WriteLine(device.Model + " " + " Color: " + device.Color + " " +
                                  " Memory size: " + device.MemorySize + "Gb " +
                                  " Cost: " + device.Price + " BYN");
            }

            ////Сортировка покупателей
            //var sortedCustomers = customerService.GetSorted("name"); // Метод работает!!!

            //Console.WriteLine("\nОтсортированный список покупателей: \n");
            //foreach (var customer in sortedCustomers)
            //{
            //    Console.WriteLine(customer.Name + " " + customer.Surname + " " + customer.PhoneNumber);
            //}
        }
    }
}