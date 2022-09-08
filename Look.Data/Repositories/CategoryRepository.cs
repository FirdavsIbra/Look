using Look.Data.DbContexts;
using Look.Data.IRepositories;
using Look.Domain.Entities.Categories;

namespace Look.Data.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(LookDbContext dbContext) : base(dbContext)
        {
        }
    }
}
