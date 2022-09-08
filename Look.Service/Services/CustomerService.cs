using AutoMapper;
using Look.Data.IRepositories;
using Look.Domain.Entities.Configurations;
using Look.Domain.Entities.Customers;
using Look.Service.DTOs.CustomerForCreationDto;
using Look.Service.Exceptions;
using Look.Service.Helpers;
using Look.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Look.Service.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CustomerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Customer> AddAsync(CustomerForCreation dto)
        {
            var exist = await _unitOfWork.Customers.GetAsync(c => c.Email == dto.Email);

            if (exist is not null)
                throw new LookException(404, "Customer already exist");

            var mappedCustomer = _mapper.Map<Customer>(dto);

            var result = await _unitOfWork.Customers.AddAsync(mappedCustomer);

            await _unitOfWork.SaveChangesAsync();

            return result;
        }

        public async Task<bool> DeleteAsync(Expression<Func<Customer, bool>> expression)
        {
            var customer = await _unitOfWork.Customers.GetAsync(expression);

            if (customer is null)
                throw new LookException(404, "Customer not found");


            await _unitOfWork.Customers.DeleteAsync(expression);

            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync(PaginationParams @params, Expression<Func<Customer, bool>> expression = null)
        {
            var pagedList = _unitOfWork.Customers.GetAllAsync(expression, isTracking: false).ToPagedList(@params);

            return await pagedList.ToListAsync();
        }

        public async Task<Customer> GetAsync(Expression<Func<Customer, bool>> expression)
        {
            var customer = await _unitOfWork.Customers.GetAsync(expression);

            if (customer is null)
                throw new LookException(404, "Customer not found");

            return customer;
        }

        public async Task<Customer> UpdateAsync(long id, CustomerForCreation dto)
        {
            var customer = await _unitOfWork.Customers.GetAsync(p => p.Id == id);

            if (customer is null)
                throw new LookException(404, "Product not found");

            var mappedCustomer = _mapper.Map(dto, customer);

            var updatedCustomer = await _unitOfWork.Customers.UpdateAsync(mappedCustomer);

            await _unitOfWork.SaveChangesAsync();

            return updatedCustomer;
        }
    }
}
