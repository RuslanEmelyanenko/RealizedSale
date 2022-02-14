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

            var deviceRepository = new DeviceRepository(dbContext);
            var deviceService = new DeviceService(deviceRepository, colorRepository, memorySizeRepository, deviceTypeRepository);

            var customerRepository = new CustomerRepository(dbContext);
            var customerService = new CustomerService(customerRepository); 

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
             //
             // 
            deviceService.AddRangeDevices(iPhones);
             //
             //
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

            var realizedSale = new RealizedSaleDto
            {
                Amount = 1,
                CustomerName = "Rustam",
                CustomerSurname = "Nurlanov",
                CustomerPhoneNumber = "+375 17 0000000",
                Date = "2021.12.24",
                DeviceModel = "iphone XR"
            };
            var realisedSale2 = new RealizedSaleDto
            {
                Amount = 1,
                CustomerName = "Svetlana",
                CustomerSurname = "Smirnova",
                CustomerPhoneNumber = "+375 17 1005025",
                Date = "2021.12.12",
                DeviceModel = "iphone 11"
            };
            var realisedSale3 = new RealizedSaleDto
            {
                Amount = 1,
                CustomerName = "Sofa",
                CustomerSurname = "Costochka",
                CustomerPhoneNumber = "+375 20 1923210",
                Date = "2021.02.13",
                DeviceModel = "iphone 11"
            };
            var realisedSale4 = new RealizedSaleDto
            {
                Amount = 1,
                CustomerName = "Daniel",
                CustomerSurname = "Scot",
                CustomerPhoneNumber = "+341 232 1923210",
                Date = "2021.02.23",
                DeviceModel = "iphone XR"
            };
            var realisedSale5 = new RealizedSaleDto
            {
                Amount = 1,
                CustomerName = "Vladimir",
                CustomerSurname = "Lobanov",
                CustomerPhoneNumber = "+375 17 9212310",
                Date = "2021.02.15",
                DeviceModel = "iphone 12 mini"
            };

            var sales = new List<RealizedSaleDto>
            {
                realizedSale, realisedSale2, realisedSale3, realisedSale4, realisedSale5
            };

            foreach (var sale in sales)
            {
                //realizedSaleService.CreateRealizedSale(sale);
            }

            //realizedSaleService.DeleteRealizedSale("2021.12.24");

            var devices = deviceService.GetAllDevices();

            Console.WriteLine($"\nType/ Model/ Color/ Size/ Price\n ");
            foreach (var device in devices)
            {
                Console.WriteLine(device.DeviceType + " " +
                                  device.Model + " " +
                                  device.Color + " " +
                                  device.MemorySize + " " +
                                  device.Price);
            }

            var realizedSales = realizedSaleService.GetAllSales();

            Console.WriteLine($"\nДата продажи/ Данные покупателя/ модель устройства/ кол-во\n");
            foreach (var sale in realizedSales)
            {
                Console.WriteLine(sale.Date + " " +
                                  sale.CustomerName + " " +
                                  sale.CustomerSurname + " " +
                                  sale.CustomerPhoneNumber + " " +
                                  sale.DeviceModel + " " +
                                  sale.Amount);
            }

            var countRealizedSales = realizedSaleService.GetNumberOfDevicesSoldByModel();

            Console.WriteLine("");
            foreach (var item in countRealizedSales)
            {
                //Console.WriteLine(item.Model + " " + item.CounterOfPurchasedDevices);
                Console.WriteLine($"{item.Model} - {item.CounterOfPurchasedDevices} человк(а) преобрели данный девайс");
            }

            ////Сортировка девайсов
            //var sortedDevices = deviceService.GetSorted("model"); // Метод работает!!!

            //Console.WriteLine("\nОтсортированный список девайсов: \n");
            //foreach (var device in sortedDevices)
            //{
            //    Console.WriteLine(device.Model + " " + " Color: " + device.Color + " " +
            //                      " Memory size: " + device.MemorySize + "Gb " +
            //                      " Cost: " + device.Price + " BYN");
            //}

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