using System.Collections.Generic;
using System.Threading.Tasks;
using NewProject_RealizedSale.Dtos.BaseDtos;
using NewProject_RealizedSale.Dtos.CreateUpdate;
using NewProject_RealizedSale.Dtos.Sorted;

namespace NewProject_RealizedSale.Services.Abstractions
{
    public interface ICustomerService
    {
        void CreateCustomer(CustomerDto createCustomer);

        Task<IList<SortedCustomerDTO>> GetSortedAsync(string sortBy);

        Task<CustomerDto> GetCustomerByNameAndSurnameAsync(string name, string surname);

        Task UpdateCustomerAsync(UpdateCustomerDto updateCustomer);
    }
}