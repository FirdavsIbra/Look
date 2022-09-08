using Look.Data.DbContexts;
using Look.Data.IRepositories;

namespace Look.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LookDbContext _dbContext;

        public UnitOfWork(LookDbContext dbContext)
        {
            _dbContext = dbContext;

            Customers = new CustomerRepository(dbContext);
            Products = new ProductRepository(dbContext);
            Categories = new CategoryRepository(dbContext);
            Payments = new PaymentRepository(dbContext);
            Orders = new OrderRepository(dbContext);
        }
        public ICustomerRepository Customers { get; }
        public IProductRepository Products { get; }
        public ICategoryRepository Categories { get; }
        public IPaymentRepository Payments { get; }
        public IOrderRepository Orders { get; }

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
