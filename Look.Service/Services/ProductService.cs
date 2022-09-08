using AutoMapper;
using Look.Data.IRepositories;
using Look.Data.Repositories;
using Look.Domain.Entities.Configurations;
using Look.Domain.Entities.Products;
using Look.Service.DTOs.ProductForCreationDto;
using Look.Service.Exceptions;
using Look.Service.Helpers;
using Look.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Look.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Product> AddAsync(ProductForCreation dto)
        {
            var exist = await _unitOfWork.Products.GetAsync(c => c.Name == dto.Name);

            if (exist is not null)
                throw new LookException(404, "Product already exist");


            var category = await _unitOfWork.Categories.GetAsync(p => p.Id == dto.CategoryId);

            if (category is null)
            {
                throw new LookException(404, "Category not found!");
            }

            var mappedProduct = _mapper.Map<Product>(dto);

            var result = await _unitOfWork.Products.AddAsync(mappedProduct);

            await _unitOfWork.SaveChangesAsync();

            return result;
        }

        public async Task<bool> DeleteAsync(Expression<Func<Product, bool>> expression)
        {
            var product = await _unitOfWork.Products.GetAsync(expression);

            if (product is null)
                throw new LookException(404, "Product not found");

            await _unitOfWork.Products.DeleteAsync(expression);

            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Product>> GetAllAsync(PaginationParams @params, Expression<Func<Product, bool>> expression = null)
        {
            var pagedList = _unitOfWork.Products.GetAllAsync(expression, isTracking: false).ToPagedList(@params);

            return await pagedList.ToListAsync();
        }

        public async Task<Product> GetAsync(Expression<Func<Product, bool>> expression)
        {
            var product = await _unitOfWork.Products.GetAsync(expression);

            if (product is null)
                throw new LookException(404, "Product not found");

            return product;
        }

        public async Task<Product> UpdateAsync(long id, ProductForCreation dto)
        {
            var product = await _unitOfWork.Products.GetAsync(p => p.Id == id);

            if (product is null)
                throw new LookException(404, "Product not found");

            var mappedProduct = _mapper.Map(dto, product);

            var updatedProduct = await _unitOfWork.Products.UpdateAsync(mappedProduct);

            await _unitOfWork.SaveChangesAsync();

            return updatedProduct;
        }
    }
}
