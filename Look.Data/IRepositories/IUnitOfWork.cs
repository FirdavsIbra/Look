using Look.Data.Repositories;
using Look.Domain.Entities.Categories;
using Look.Domain.Entities.Customers;
using Look.Domain.Entities.Orders;
using Look.Domain.Entities.Payments;
using Look.Domain.Entities.Products;

namespace Look.Data.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Customer> Customers { get; }
        IGenericRepository<Product> Products { get; }
        IGenericRepository<Category> Categories { get; }
        IGenericRepository<Payment> Payments { get; }
        IGenericRepository<Order> Orders { get; }

        Task SaveChangesAsync();

    }
}
