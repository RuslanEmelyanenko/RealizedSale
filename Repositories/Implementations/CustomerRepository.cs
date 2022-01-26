using System.Linq;
using NewProject_RealizedSale.Models;

namespace NewProject_RealizedSale.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>
    {
        private readonly SaleContext _dbContext;

        public CustomerRepository(SaleContext dbContext) 
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Customer GetCustomerByNameAndSurname(string name, string surname)
        {
            var customer = _dbContext.Customers.FirstOrDefault(cn => cn.Name == name && cn.Surname == surname);

            return customer;
        }
    }
}