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

        public Customer GetByCustomerNameAndSurname(string name, string surname)
        {
            var customer = DbContext.Customers.Where(cn => cn.Name == name).OrderBy(cs => cs.Surname == surname);

            return (Customer)customer;
        }
    }
}
