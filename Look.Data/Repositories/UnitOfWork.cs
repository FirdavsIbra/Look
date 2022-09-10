using Look.Data.DbContexts;
using Look.Data.IRepositories;
using Look.Domain.Entities.Categories;
using Look.Domain.Entities.Customers;
using Look.Domain.Entities.Orders;
using Look.Domain.Entities.Payments;
using Look.Domain.Entities.Products;

namespace Look.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LookDbContext _dbContext;

        public UnitOfWork(LookDbContext dbContext)
        {
            _dbContext = dbContext;

            Customers = new GenericRepository<Customer>(_dbContext);
            Products = new GenericRepository<Product>(_dbContext);
            Categories = new GenericRepository<Category>(_dbContext);
            Payments = new GenericRepository<Payment>(_dbContext);
            Orders = new GenericRepository<Order>(_dbContext);

        }
        public IGenericRepository<Customer> Customers { get; }
        public IGenericRepository<Product> Products { get; }
        public IGenericRepository<Category> Categories { get; }
        public IGenericRepository<Payment> Payments { get; }
        public IGenericRepository<Order> Orders { get; }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
