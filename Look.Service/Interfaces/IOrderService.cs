using Look.Domain.Entities.Configurations;
using Look.Domain.Entities.Orders;
using Look.Service.DTOs.OrderForCreationDto;
using System.Linq.Expressions;

namespace Look.Service.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetAllAsync(PaginationParams @params, Expression<Func<Order, bool>> expression = null);
        Task<Order> GetAsync(Expression<Func<Order, bool>> expression);
        Task<Order> AddAsync(OrderForCreation dto);
        Task<Order> UpdateAsync(long id, OrderForCreation dto);
        Task<bool> DeleteAsync(Expression<Func<Order, bool>> expression);
    }
}
