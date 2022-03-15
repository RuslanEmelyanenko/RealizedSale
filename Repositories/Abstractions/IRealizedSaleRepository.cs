using System.Collections.Generic;
using System.Threading.Tasks;
using NewProject_RealizedSale.Models;

namespace NewProject_RealizedSale.Repositories.Abstractions
{
    public interface IRealizedSaleRepository : IBaseRepository<RealizedSale>
    {
        List<RealizedSale> GetNumberOfDevicesSoldByModel();

        Task<RealizedSale> GetByRealizedSaleAsync(string date);
        Task<IList<RealizedSale>> GetAllRealizedSaleAsync();
    }
}