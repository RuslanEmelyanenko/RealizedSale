using System.Linq;
using NewProject_RealizedSale.Models;

namespace NewProject_RealizedSale.Repositories
{
    public class MemorySizeRepository : BaseRepository<MemorySize>
    {
        private readonly SaleContext _dbContext;

        public MemorySizeRepository(SaleContext dbContext) 
           : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public MemorySize GetByMemorySize(int memorySize)
        {
            var memory = _dbContext.Memory.FirstOrDefault(m => m.MemorySizeDevice == memorySize);

            return memory;
        }
    }
}