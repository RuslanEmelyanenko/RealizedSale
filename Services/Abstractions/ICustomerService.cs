using System.Collections.Generic;
using NewProject_RealizedSale.Dtos.Sorted;

namespace NewProject_RealizedSale.Services.Abstractions
{
    public interface ICustomerService
    {
        IList<SortedCustomerDTO> GetSorted(string sortBy);
    }
}