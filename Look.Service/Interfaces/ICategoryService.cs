using Look.Domain.Entities.Categories;
using Look.Domain.Entities.Configurations;
using Look.Service.DTOs.CategoryForCreationDto;
using System.Linq.Expressions;

namespace Look.Service.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllAsync(PaginationParams @params, Expression<Func<Category, bool>> expression = null);
        Task<Category> GetAsync(Expression<Func<Category, bool>> expression);
        Task<Category> AddAsync(CategoryForCreation dto);
        Task<Category> UpdateAsync(long id, CategoryForCreation dto);
        Task<bool> DeleteAsync(Expression<Func<Category, bool>> expression);
    }
}
