using AutoMapper;
using Look.Data.IRepositories;
using Look.Domain.Entities.Configurations;
using Look.Domain.Entities.Orders;
using Look.Domain.Entities.Products;
using Look.Service.DTOs.OrderForCreationDto;
using Look.Service.Exceptions;
using Look.Service.Helpers;
using Look.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Look.Service.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Order> AddAsync(OrderForCreation dto)
        {
            var mappedOrder = _mapper.Map<Order>(dto);

            var result = await _unitOfWork.Orders.AddAsync(mappedOrder);

            await _unitOfWork.SaveChangesAsync();

            return result;
        }

        public async Task<bool> DeleteAsync(Expression<Func<Order, bool>> expression)
        {
            var order = await _unitOfWork.Orders.GetAsync(expression);

            if (order is null)
                throw new LookException(404, "Order not found");

            await _unitOfWork.Orders.DeleteAsync(expression);

            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Order>> GetAllAsync(PaginationParams @params, Expression<Func<Order, bool>> expression = null)
        {
            var pagedList = _unitOfWork.Orders.GetAllAsync(expression, isTracking: false).ToPagedList(@params);

            return await pagedList.ToListAsync();
        }

        public async Task<Order> GetAsync(Expression<Func<Order, bool>> expression)
        {
            var order = await _unitOfWork.Orders.GetAsync(expression);

            if (order is null)
                throw new LookException(404, "Order not found");

            return order;
        }

        public async Task<Order> UpdateAsync(long id, OrderForCreation dto)
        {
            var order = await _unitOfWork.Orders.GetAsync(p => p.Id == id);

            if (order is null)
                throw new LookException(404, "Order not found");

            var mappedOrder = _mapper.Map(dto, order);

            var updatedOrder = await _unitOfWork.Orders.UpdateAsync(mappedOrder);

            await _unitOfWork.SaveChangesAsync();

            return updatedOrder;
        }
    }
}
