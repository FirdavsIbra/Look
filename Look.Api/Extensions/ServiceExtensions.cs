using Look.Data.IRepositories;
using Look.Data.Repositories;
using Look.Service.Interfaces;
using Look.Service.Services;

namespace Look.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IPaymentService, PaymentService>();
        }
    }
}