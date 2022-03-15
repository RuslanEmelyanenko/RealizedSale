using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewProject_RealizedSale.Models;
using NewProject_RealizedSale.Repositories.Abstractions;

namespace NewProject_RealizedSale.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        private readonly SaleContext _dbContext;

        public CustomerRepository(SaleContext dbContext) 
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Customer> GetCustomerByNameAndSurnameAsync(string name, string surname)
        {
            var customer = await _dbContext.Customers.FirstOrDefaultAsync(cn => cn.Name == name && cn.Surname == surname);

            return customer;
        }
    }
}