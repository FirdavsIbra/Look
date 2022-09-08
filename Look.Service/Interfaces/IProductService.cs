using Look.Domain.Entities.Configurations;
using Look.Domain.Entities.Products;
using Look.Service.DTOs.ProductForCreationDto;
using System.Linq.Expressions;

namespace Look.Service.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllAsync(PaginationParams @params, Expression<Func<Product, bool>> expression = null);
        Task<Product> GetAsync(Expression<Func<Product, bool>> expression);
        Task<Product> AddAsync(ProductForCreation dto);
        Task<Product> UpdateAsync(long id, ProductForCreation dto);
        Task<bool> DeleteAsync(Expression<Func<Product, bool>> expression);
    }

}
