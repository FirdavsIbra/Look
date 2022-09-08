using Look.Domain.Entities.Configurations;
using Look.Domain.Entities.Payments;
using Look.Service.DTOs.PaymentForCreationDto;
using System.Linq.Expressions;

namespace Look.Service.Interfaces
{
    public interface IPaymentService
    {
        Task<IEnumerable<Payment>> GetAllAsync(PaginationParams @params, Expression<Func<Payment, bool>> expression = null);
        Task<Payment> GetAsync(Expression<Func<Payment, bool>> expression);
        Task<Payment> AddAsync(PaymentForCreation dto);
        Task<Payment> UpdateAsync(long id, PaymentForCreation dto);
        Task<bool> DeleteAsync(Expression<Func<Payment, bool>> expression);
    }
}
