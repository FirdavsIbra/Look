namespace Look.Data.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository Customers { get; }
        IProductRepository Products { get; }
        ICategoryRepository Categories { get; }
        IPaymentRepository Payments { get; }
        IOrderRepository Orders { get; }

        Task SaveChangesAsync();

    }
}
