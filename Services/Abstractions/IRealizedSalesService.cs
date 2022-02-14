using System.Collections.Generic;
using NewProject_RealizedSale.Dtos;
using NewProject_RealizedSale.Dtos.BaseDtos;

namespace NewProject_RealizedSale.Services.Abstractions
{
    interface IRealizedSalesService
    {
        IList<RealizedSaleDto> GetAllSales();
        //IList<CounterOfPurchasedDevicesDto> GetNumberOfDevicesSoldByModel();
    }
}