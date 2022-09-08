using AutoMapper;
using Look.Data.IRepositories;
using Look.Data.Repositories;
using Look.Domain.Entities.Categories;
using Look.Domain.Entities.Configurations;
using Look.Domain.Entities.Payments;
using Look.Service.DTOs.CategoryForCreationDto;
using Look.Service.DTOs.PaymentForCreationDto;
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
    public class PaymentService : IPaymentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PaymentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Payment> AddAsync(PaymentForCreation dto)
        {
            //Check for payment
            var order = await _unitOfWork.Orders.GetAsync(o => o.Id == dto.OrderId);

            if (order is null || order.IsPaid)
                throw new LookException(404,"Order not found");

            order.IsPaid = true;

            var mappedPayment = _mapper.Map<Payment>(dto);

            var result = await _unitOfWork.Payments.AddAsync(mappedPayment);

            await _unitOfWork.SaveChangesAsync();

            return result;
        }

        public async Task<bool> DeleteAsync(Expression<Func<Payment, bool>> expression)
        {
            var payment = await _unitOfWork.Payments.GetAsync(expression);

            if (payment is null)
                throw new LookException(404, "Payment not found");


            await _unitOfWork.Payments.DeleteAsync(expression);

            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Payment>> GetAllAsync(PaginationParams @params, Expression<Func<Payment, bool>> expression = null)
        {
            var pagedList = _unitOfWork.Payments.GetAllAsync(expression, isTracking: false).ToPagedList(@params);

            return await pagedList.ToListAsync();
        }

        public async Task<Payment> GetAsync(Expression<Func<Payment, bool>> expression)
        {
            var payment = await _unitOfWork.Payments.GetAsync(expression);

            if (payment is null)
                throw new LookException(404, "Payment not found");

            return payment;
        }


        public async Task<Payment> UpdateAsync(long id, PaymentForCreation dto)
        {
            var payment = await _unitOfWork.Payments.GetAsync(p => p.Id == id);

            if (payment is null)
                throw new LookException(404, "This kind of category not found");

            var mappedPayment = _mapper.Map(dto, payment);

            var updatedPayment = await _unitOfWork.Payments.UpdateAsync(mappedPayment);

            await _unitOfWork.SaveChangesAsync();

            return updatedPayment;
        }
    }
}
