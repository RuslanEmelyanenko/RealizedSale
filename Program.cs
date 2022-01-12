using System;
using System.Collections.Generic;
using System.Linq;
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
            var deviceRepository = new DeviceRepository(dbContext);
            var deviceService = new DeviceService(deviceRepository);

            var colorRepository = new ColorRepository(dbContext);
            var memorySizeRepository = new MemorySizeRepository(dbContext);
            var deviceTypeRepository = new DeviceTypeRepository(dbContext);

            {
                // Type devices
                var deviceTypePhone = new DeviceType
                {
                    Type = "Phone"
                };
                var deviceTypeTablet = new DeviceType
                {
                    Type = "Tablet"
                };
                var deviceTypeNotebook = new DeviceType
                {
                    Type = "Notebook"
                };

                // Colors
                var colorBlack = new Color
                {
                    ColorDevice = "Black"
                };
                var colorWhite = new Color
                {
                    ColorDevice = "White"
                };
                var colorSilver = new Color
                {
                    ColorDevice = "Silver"
                };
                var colorSpaceGray = new Color
                {
                    ColorDevice = "SpaceGray"
                };
                var colorGold = new Color
                {
                    ColorDevice = "Gold"
                };
                var colorPinckGold = new Color
                {
                    ColorDevice = "PinckGold"
                };
                var colorGreen = new Color
                {
                    ColorDevice = "Green"
                };
                var colorYellow = new Color
                {
                    ColorDevice = "Yellow"
                };
                var colorBlue = new Color
                {
                    ColorDevice = "Blue"
                };
                var colorRed = new Color
                {
                    ColorDevice = " Red"
                };
                var colorPurple = new Color
                {
                    ColorDevice = " Purple"
                };
                var colorOrange = new Color
                {
                    ColorDevice = "Orange"
                };

                // Memory sizes
                var memorySize32 = new MemorySize
                {
                    MemorySizeDevice = 32
                };
                var memorySize64 = new MemorySize
                {
                    MemorySizeDevice = 64
                };
                var memorySize128 = new MemorySize
                {
                    MemorySizeDevice = 128
                };
                var memorySize256 = new MemorySize
                {
                    MemorySizeDevice = 256
                };
                var memorySize512 = new MemorySize
                {
                    MemorySizeDevice = 512
                };
                var memorySize1024 = new MemorySize
                {
                    MemorySizeDevice = 1024
                };

                // Phones
                var black = colorRepository.Get(85);
                var white = colorRepository.Get(86);
                var silver = colorRepository.Get(87);
                var spaceGray = colorRepository.Get(88);
                var gold = colorRepository.Get(89);
                var green = colorRepository.Get(91);

                var size64 = memorySizeRepository.Get(20);
                var size128 = memorySizeRepository.Get(21);
                var size256 = memorySizeRepository.Get(22);

                var phone = deviceTypeRepository.Get(31);

                var pSe64 = new Device
                {
                    Model = "iPhone SE",
                    Price = 1299.0,
                    Color = black,
                    MemorySize = size64,
                    DeviceType = phone
                };
                var pSe128 = new Device
                {
                    Model = "iPhone SE",
                    Price = 1499.0,
                    Color = white,
                    MemorySize = size128,
                    DeviceType = phone
                };
                var pSe256 = new Device
                {
                    Model = "iPhone SE",
                    Price = 2099.0,
                    Color = spaceGray,
                    MemorySize = size256,
                    DeviceType = phone
                };
                var p11_64 = new Device
                {
                    Model = "iPhone 11",
                    Price = 1999.0,
                    Color = green,
                    MemorySize = size64,
                    DeviceType = phone
                };
                var p11_128 = new Device
                {
                    Model = "iPhone 11",
                    Price = 2199.0,
                    Color = white,
                    MemorySize = size128,
                    DeviceType = phone
                };
                var pXr64 = new Device
                {
                    Model = "iPhone XR",
                    Price = 1899.0,
                    Color = white,
                    MemorySize = size64,
                    DeviceType = phone
                };
                var pXr128 = new Device
                {
                    Model = "iPhone XR",
                    Price = 2099.0,
                    Color = gold,
                    MemorySize = size128,
                    DeviceType = phone
                };
                var p12mini128 = new Device
                {
                    Model = "iPhone 12 mini",
                    Price = 2499.0,
                    Color = white,
                    MemorySize = size128,
                    DeviceType = phone
                };
                var p12mini256 = new Device
                {
                    Model = "iPhone 12 mini",
                    Price = 3199.0,
                    Color = gold,
                    MemorySize = size256,
                    DeviceType = phone
                };

                // Customers
                var customer1 = new Customer
                {
                    Name = "Ruslan",
                    Surname = "Emelyanenko",
                    PhoneNumber = "+375 33 300 00 00"
                };
                var customer2 = new Customer
                {
                    Name = "Stanislav",
                    Surname = "Ignatenko",
                    PhoneNumber = "+375 29 200 00 00"
                };
                var customer3 = new Customer
                {
                    Name = "Anna",
                    Surname = "Khalikova",
                    PhoneNumber = "+375 25 900 00 00"
                };

                // Realized sales
                var realizeSale1 = new RealizedSale
                {
                    Amount = 1,
                    TotalSum = 3199.0,
                    Date = "09.12.2021",
                    Customer = customer1,
                    Device = p12mini256
                };
                var realizeSale2 = new RealizedSale
                {
                    Amount = 1,
                    TotalSum = 2199.0,
                    Date = "30.10.2021",
                    Customer = customer2,
                    Device = p11_128
                };
                var realizeSale3 = new RealizedSale
                {
                    Amount = 1,
                    TotalSum = 2499.0,
                    Date = "09.09.2021",
                    Customer = customer3,
                    Device = pXr128
                };
                var realizeSale4 = new RealizedSale
                {
                    Amount = 1,
                    TotalSum = 2099.0,
                    Date = "09.09.2021",
                    Customer = customer3,
                    Device = p12mini128
                };

                var colors = new List<Color>
                {
                    colorBlack, colorWhite, colorSilver, colorSpaceGray, colorGold, colorPinckGold, colorGreen,
                    colorYellow, colorBlue, colorRed, colorPurple, colorOrange
                };

                var memorySize = new List<MemorySize>
                {
                    memorySize32, memorySize64, memorySize128, memorySize256, memorySize512, memorySize1024
                };

                var deviceType = new List<DeviceType>
                {
                    deviceTypePhone, deviceTypeTablet, deviceTypeNotebook
                };

                var device = new List<Device>
                {
                    pSe64, pSe128, pSe256, p11_64, p11_128, pXr64, pXr128, p12mini128, p12mini256
                };

                var customer = new List<Customer>
                {
                    customer1, customer2, customer3
                };

                var realizeSale = new List<RealizedSale>
                {
                    realizeSale1, realizeSale2, realizeSale3, realizeSale4
                };

                // Device type
                //dbContext.DeviceTypes.AddRange(deviceType);

                //dbContext.SaveChanges();

                // Color
                //dbContext.Colors.AddRange(colors);

                //dbContext.SaveChanges();

                // Memory size
                //dbContext.Memory.AddRange(memorySize);

                //dbContext.SaveChanges();

                // Phone
                //dbContext.Devices.AddRange(device);

                //dbContext.SaveChanges();

                // Customer
                //dbContext.Customers.AddRange(customer);

                //dbContext.SaveChanges();

                // Realize sale
                //dbContext.RealizedSales.AddRange(realizeSale);

                //dbContext.SaveChanges();
            }

            // Вывод объектов из базы данных на консоль!
            var printConsoleContext = new SaleContext();
            {
                // Получаем объекты из бд и выводим на консоль;
                var colors = printConsoleContext.Colors.ToList();
                Console.WriteLine("Данные таблицы Colors:");
                foreach (Color c in colors)
                {
                    Console.WriteLine($"{c.Id}--{c.ColorDevice}");
                }

                var memorySizes = printConsoleContext.Memory.ToList();
                Console.WriteLine("\nДанные таблицы MemorySizes:");
                foreach (MemorySize m in memorySizes)
                {
                    Console.WriteLine($"{m.Id}--{m.MemorySizeDevice}");
                }

                var deviceTypePhone = printConsoleContext.DeviceTypes.ToList();
                Console.WriteLine("\nДанные таблицы DeviceType:");
                foreach (DeviceType d in deviceTypePhone)
                {
                    Console.WriteLine($"{d.Id}--{d.Type}");
                }

                var devicePhone = printConsoleContext.Devices.ToList();
                Console.WriteLine("\nДанные таблицы Device:");
                Console.WriteLine($"\nID--DeviceType--Model--ColorId--MemorySizeId--Price");
                foreach (Device d in devicePhone)
                {
                    Console.WriteLine($"{d.Id}--{d.DeviceTypeId}--{d.Model}--{d.ColorId}--{d.MemorySizeId}--{d.Price}");
                }

                var realizedSales = printConsoleContext.RealizedSales.ToList();
                Console.WriteLine("\nДанные таблицы Realized Sale:");

                Console.WriteLine("Id Amount Sum Date   CustomerID DeviceID");
                foreach (RealizedSale r in realizedSales)
                {
                    Console.WriteLine($"{r.Id}--{r.Amount}--{r.TotalSum}--{r.Date}--{r.CustomerId}--{r.DeviceId}");
                }

                double totalSum = realizedSales.Where(x => x.CustomerId == 39).Sum(n => n.TotalSum);
                int amount = realizedSales.Where(x => x.CustomerId == 39).Sum(n => n.Amount);

                Console.WriteLine($"\nКолличество девайсов: {amount}\nИтоговая стоимость: {totalSum} BYN");
            }

            //Сортировка девайсов
            var sortedDevices = deviceService.GetSortedDevices("price");

            Console.WriteLine("\nОтсортированный список девайсов: \n");
            foreach (var device in sortedDevices)
            {
                Console.WriteLine(device.Model + " " + " Color: " + device.Color + " " + 
                                  " Memory size: " + device.MemorySize + "Gb " + 
                                  " Cost: " + device.Price + " BYN");
            }
        }
    }
}
