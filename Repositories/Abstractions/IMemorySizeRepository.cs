using System.Threading.Tasks;
using NewProject_RealizedSale.Models;

namespace NewProject_RealizedSale.Repositories.Abstractions
{
    interface IMemorySizeRepository : IBaseRepository<MemorySize>
    {
        Task<MemorySize> GetByMemorySizeAsync(int memorySize);
    }
}