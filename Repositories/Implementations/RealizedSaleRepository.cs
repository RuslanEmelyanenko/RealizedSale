using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewProject_RealizedSale.Models;
using NewProject_RealizedSale.Repositories.Abstractions;

namespace NewProject_RealizedSale.Repositories
{
    public class RealizedSaleRepository : BaseRepository<RealizedSale>, IRealizedSaleRepository
    {
        private readonly SaleContext _dbContext;

        public RealizedSaleRepository(SaleContext dbContext) 
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<RealizedSale> GetByRealizedSaleAsync(string date)
        {
            var sale = await _dbContext.RealizedSales.FirstOrDefaultAsync(r => r.Date == date);

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

        public async Task<IList<RealizedSale>> GetAllRealizedSaleAsync()
        {
            var realizedSale = await _dbContext.RealizedSales
                .Include(r => r.Device)
                .Include(r => r.Customer)
                .ToListAsync();

            return realizedSale;
        }

    }
}