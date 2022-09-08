using Look.Domain.Entities.Configurations;
using Look.Domain.Entities.Customers;
using Look.Service.DTOs.CustomerForCreationDto;
using System.Linq.Expressions;

namespace Look.Service.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAllAsync(PaginationParams @params, Expression<Func<Customer, bool>> expression = null);
        Task<Customer> GetAsync(Expression<Func<Customer, bool>> expression);
        Task<Customer> AddAsync(CustomerForCreation dto);
        Task<Customer> UpdateAsync(long id, CustomerForCreation dto);
        Task<bool> DeleteAsync(Expression<Func<Customer, bool>> expression);
    }
}
