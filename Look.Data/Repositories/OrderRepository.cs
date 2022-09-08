using Look.Data.DbContexts;
using Look.Data.IRepositories;
using Look.Domain.Entities.Orders;

namespace Look.Data.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(LookDbContext dbContext) : base(dbContext)
        {
        }
    }
}
