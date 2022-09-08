using Look.Data.DbContexts;
using Look.Data.IRepositories;
using Look.Domain.Entities.Payments;

namespace Look.Data.Repositories
{
    public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(LookDbContext dbContext) : base(dbContext)
        {
        }
    }
}
