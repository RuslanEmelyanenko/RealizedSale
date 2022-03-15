using System.Collections.Generic;
using System.Threading.Tasks;
using NewProject_RealizedSale.Dtos;
using NewProject_RealizedSale.Dtos.BaseDtos;

namespace NewProject_RealizedSale.Services.Abstractions
{
    interface IRealizedSalesService
    {
        Task<IList<RealizedSaleDto>> GetAllSalesAsync();
        Task<IList<CounterOfPurchasedDevicesDto>> GetNumberOfDevicesSoldByModelAsync();

        Task<RealizedSaleDto> GetRealizedSaleByDateAsync(string date);

        Task CreateRealizedSaleAsync(RealizedSaleDto createRealizedSale);
        Task DeleteRealizedSaleAsync(string date);
    }
}