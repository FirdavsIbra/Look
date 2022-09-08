using AutoMapper;
using Look.Data.IRepositories;
using Look.Domain.Entities.Categories;
using Look.Domain.Entities.Configurations;
using Look.Service.DTOs.CategoryForCreationDto;
using Look.Service.Exceptions;
using Look.Service.Helpers;
using Look.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Look.Service.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Category> AddAsync(CategoryForCreation dto)
        {
            var exist = await _unitOfWork.Categories.GetAsync(c => c.Name == dto.Name);

            if (exist is not null)
                throw new LookException(404, "Category already exist");

            var mappedCategory = _mapper.Map<Category>(dto);

            var result = await _unitOfWork.Categories.AddAsync(mappedCategory);

            await _unitOfWork.SaveChangesAsync();

            return result;
        }

        public async Task<bool> DeleteAsync(Expression<Func<Category, bool>> expression)
        {
            var product = await _unitOfWork.Categories.GetAsync(expression);

            if (product is null)
                throw new LookException(404, "This kind of category not found");


            await _unitOfWork.Categories.DeleteAsync(expression);

            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Category>> GetAllAsync(PaginationParams @params, Expression<Func<Category, bool>> expression = null)
        {
            var pagedList = _unitOfWork.Categories.GetAllAsync(expression, isTracking: false).ToPagedList(@params);

            return await pagedList.ToListAsync();
        }

        public async Task<Category> GetAsync(Expression<Func<Category, bool>> expression)
        {
            var category = await _unitOfWork.Categories.GetAsync(expression);

            if (category is null)
                throw new LookException(404, "This kind of category not found");

            return category;
        }

        public async Task<Category> UpdateAsync(long id, CategoryForCreation dto)
        {
            var category = await _unitOfWork.Categories.GetAsync(p => p.Id == id);

            if (category is null)
                throw new LookException(404, "This kind of category not found");

            var mappedCategory = _mapper.Map(dto, category);

            var updatedCategory = await _unitOfWork.Categories.UpdateAsync(mappedCategory);

            await _unitOfWork.SaveChangesAsync();

            return updatedCategory;
        }
    }
}
