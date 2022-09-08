using Look.Data.DbContexts;
using Look.Data.IRepositories;
using Look.Domain.Entities.Products;

namespace Look.Data.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(LookDbContext dbContext) : base(dbContext)
        {
        }
    }
}
