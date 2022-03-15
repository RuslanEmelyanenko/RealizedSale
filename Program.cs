using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewProject_RealizedSale.Dtos.BaseDtos;
using NewProject_RealizedSale.Models;
using NewProject_RealizedSale.Repositories;
using NewProject_RealizedSale.Services.Implementations;

namespace NewProject_RealizedSale
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            using (var dbContext = new SaleContext())
            {
                var colorRepository = new ColorRepository(dbContext);
                var memorySizeRepository = new MemorySizeRepository(dbContext);
                var deviceTypeRepository = new DeviceTypeRepository(dbContext);

                var deviceRepository = new DeviceRepository(dbContext);
                var deviceService = new DeviceService(deviceRepository, colorRepository, memorySizeRepository, deviceTypeRepository);

                var customerRepository = new CustomerRepository(dbContext);
                var customerService = new CustomerService(customerRepository);

                var realizedSaleRepository = new RealizedSaleRepository(dbContext);
                var realizedSaleService = new RealizedSalesService(realizedSaleRepository, deviceRepository, customerRepository);

                var devices = await deviceService.GetAllDevicesAsync();

                Console.WriteLine($"\nType/ Model/ Color/ Size/ Price\n ");
                foreach (var device in devices)
                {
                    Console.WriteLine(device.DeviceType + " " +
                                      device.Model + " " +
                                      device.Color + " " +
                                      device.MemorySize + " Gb" + " " +
                                      device.Price + " BYN");
                }

                var realizedSales = await realizedSaleService.GetAllSalesAsync();

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

                var countRealizedSales = await realizedSaleService.GetNumberOfDevicesSoldByModelAsync();

                Console.WriteLine("");
                foreach (var item in countRealizedSales)
                {
                    //Console.WriteLine(item.Model + " " + item.CounterOfPurchasedDevices);
                    Console.WriteLine($"{item.Model} - {item.CounterOfPurchasedDevices} человк(а) преобрели данный девайс");
                }
            }
            
            //var phoneSe64 = new DeviceDto
            //{
            //    Model = "iPhone SE",
            //    Price = 1299.0,
            //    Color = "Black",
            //    MemorySize = 64,
            //    DeviceType = "Phone"
            //};

            //var iPhones = new List<DeviceDto>
            //{
            //    phoneSe64, phoneSe128, phoneSe256, phone11_64, phone11_128, phoneXr64, phoneXr128, phone12mini128, phone12mini256
            //};

            //deviceService.AddRangeDevices(iPhones);

            //foreach (var iPhone in iPhones)
            //{
            //    //deviceService.CreateDevice(iPhone);
            //}

            //var customer1 = new CustomerDto
            //{
            //    Name = "Ruslan",
            //    Surname = "Emelyanenk",
            //    PhoneNumber = "+375 33 0000000"
            //};
           
            //var customers = new List<CustomerDto>
            //{
            //    customer1, customer2, customer3
            //};

            //foreach (var customer in customers)
            //{
            //    //customerService.CreateCustomer(customer);
            //}

            ////deviceService.DeleteDevice("iPhone SE");  // Метод работает!!!

            //var realizedSale = new RealizedSaleDto
            //{
            //    Amount = 1,
            //    CustomerName = "Rustam",
            //    CustomerSurname = "Nurlanov",
            //    CustomerPhoneNumber = "+375 17 0000000",
            //    Date = "2021.12.24",
            //    DeviceModel = "iphone XR"
            //};
            
            //var sales = new List<RealizedSaleDto>
            //{
            //    realizedSale, realisedSale2, realisedSale3, realisedSale4, realisedSale5
            //};

            //foreach (var sale in sales)
            //{
            //    //realizedSaleService.CreateRealizedSale(sale);
            //}

            //realizedSaleService.DeleteRealizedSale("2021.12.24");

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