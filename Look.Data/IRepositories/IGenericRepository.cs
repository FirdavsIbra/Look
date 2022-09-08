using Look.Domain.Entities.Commons;
using System.Linq.Expressions;

namespace Look.Data.IRepositories
{
    public interface IGenericRepository<T> where T : Auditable
    {
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<bool> DeleteAsync(Expression<Func<T, bool>> expression);
        IQueryable<T> GetAllAsync(Expression<Func<T, bool>> expression = null, string include = null, bool isTracking = true);
        Task<T> GetAsync(Expression<Func<T, bool>> expression);
    }
}
