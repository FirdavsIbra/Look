using Look.Domain.Entities.Categories;
using Look.Domain.Entities.Customers;
using Look.Domain.Entities.Orders;
using Look.Domain.Entities.Payments;
using Look.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;

namespace Look.Data.DbContexts
{
    public class LookDbContext : DbContext
    {
        public LookDbContext(DbContextOptions<LookDbContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
    }
}
