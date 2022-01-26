using System.Linq;
using NewProject_RealizedSale.Models;

namespace NewProject_RealizedSale.Repositories
{
    public class ColorRepository : BaseRepository<Color>
    {
        private readonly SaleContext _dbContext;

        public ColorRepository(SaleContext dbContext) 
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Color GetByColorName(string colorDevice)
        {
            var color = _dbContext.Colors.FirstOrDefault(c => c.ColorDevice == colorDevice);

            return color;
        }
    }
}
