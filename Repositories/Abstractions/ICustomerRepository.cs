using System.Collections.Generic;
using NewProject_RealizedSale.Models;

namespace NewProject_RealizedSale.Repositories.Abstractions
{
    interface ICustomerRepository : IBaseRepository<Customer>
    {
        IList<Customer> GetAllCustomers();
    }
}