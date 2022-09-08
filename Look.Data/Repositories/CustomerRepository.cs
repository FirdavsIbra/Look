using Look.Data.DbContexts;
using Look.Data.IRepositories;
using Look.Domain.Entities.Customers;

namespace Look.Data.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(LookDbContext dbContext) : base(dbContext)
        {
        }
    }
}
