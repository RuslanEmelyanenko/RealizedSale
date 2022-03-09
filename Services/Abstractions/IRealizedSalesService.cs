using System.Collections.Generic;
using System.Threading.Tasks;
using NewProject_RealizedSale.Dtos.BaseDtos;

namespace NewProject_RealizedSale.Services.Abstractions
{
    interface IRealizedSalesService
    {
        Task<IList<RealizedSaleDto>> GetAllSalesAsync();
    }
}