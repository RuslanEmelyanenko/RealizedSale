using System.Collections.Generic;
using NewProject_RealizedSale.Models;

namespace NewProject_RealizedSale.Repositories.Abstractions
{
    public interface IRealizedSaleRepository : IBaseRepository<RealizedSale>
    {
        IList<RealizedSale> GetAllRealizedSales();
    }
}