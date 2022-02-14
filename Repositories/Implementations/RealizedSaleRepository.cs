using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NewProject_RealizedSale.Models;

namespace NewProject_RealizedSale.Repositories
{
    public class RealizedSaleRepository : BaseRepository<RealizedSale>
    {
        private readonly SaleContext _dbContext;

        public RealizedSaleRepository(SaleContext dbContext) 
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public RealizedSale GetByRealizedSale(string date)
        {
            var sale = _dbContext.RealizedSales.FirstOrDefault(r => r.Date == date);

            return sale;
        }

        public List<RealizedSale> GetNumberOfDevicesSoldByModel()
        {
            var countSale = _dbContext.RealizedSales.GroupBy(r => r.Device.DeviceType.Type)
                .Select(g => new
                {
                    Model = g.Key,
                    CountDevice = g.Count()
                });

            return (List<RealizedSale>)countSale;
        }

        public IList<RealizedSale> GetAllRealizedSale()
        {
            var realizedSale = _dbContext.RealizedSales
                .Include(r => r.Device)
                .Include(r => r.Customer)
                .ToList();

            return realizedSale;
        }

    }
}