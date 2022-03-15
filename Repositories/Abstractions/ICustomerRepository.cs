using System.Collections.Generic;
using System.Threading.Tasks;
using NewProject_RealizedSale.Models;

namespace NewProject_RealizedSale.Repositories.Abstractions
{
    interface ICustomerRepository : IBaseRepository<Customer>
    {
        Task<Customer> GetCustomerByNameAndSurnameAsync(string name, string surname);

        //IList<Customer> GetAllCustomers();
    }
}