using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewProject_RealizedSale.Models;
using NewProject_RealizedSale.Repositories.Abstractions;

namespace NewProject_RealizedSale.Repositories
{
    public class ColorRepository : BaseRepository<Color>, IColorRepository
    {
        private readonly SaleContext _dbContext;

        public ColorRepository(SaleContext dbContext) 
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Color> GetByColorNameAsync(string colorDevice)
        {
            var color = await _dbContext.Colors.FirstOrDefaultAsync(c => c.ColorDevice == colorDevice);

            return color;
        }
    }
}