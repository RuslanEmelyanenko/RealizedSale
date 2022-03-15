using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewProject_RealizedSale.Models;
using NewProject_RealizedSale.Repositories.Abstractions;

namespace NewProject_RealizedSale.Repositories
{
    public class MemorySizeRepository : BaseRepository<MemorySize>, IMemorySizeRepository
    {
        private readonly SaleContext _dbContext;

        public MemorySizeRepository(SaleContext dbContext) 
           : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<MemorySize> GetByMemorySizeAsync(int memorySize)
        {
            var memory = await _dbContext.Memory.FirstOrDefaultAsync(m => m.MemorySizeDevice == memorySize);

            return memory;
        }
    }
}