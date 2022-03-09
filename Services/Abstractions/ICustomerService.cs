using System.Collections.Generic;
using System.Threading.Tasks;
using NewProject_RealizedSale.Dtos.Sorted;

namespace NewProject_RealizedSale.Services.Abstractions
{
    public interface ICustomerService
    {
        Task<IList<SortedCustomerDTO>> GetSortedAsync(string sortBy);
    }
}