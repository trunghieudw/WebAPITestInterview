using DataAccessEF.Interfaces;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.DTOs;
using System.Linq;

namespace Services.Orders
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<OrderResponse>> GetAllAsync()
        {
            var orders = _unitOfWork.RepositoryAsync<Order>().GetAll();
            return orders.Select(o => new OrderResponse
            {
                Id = o.OrderId,
                CustomerId = o.CustomerId,
                OrderDate = o.OrderDate,
                TotalAmount = o.TotalAmount,
                // Mapping OrderItems nếu cần
            });
        }
        public async Task<OrderResponse> GetByIdAsync(int id)
        {
            var o = _unitOfWork.RepositoryAsync<Order>().GetById(id);
            if (o == null) return null;
            return new OrderResponse
            {
                Id = o.OrderId,
                CustomerId = o.CustomerId,
                OrderDate = o.OrderDate,
                TotalAmount = o.TotalAmount,
                // Mapping OrderItems nếu cần
            };
        }
        public async Task<OrderResponse> AddAsync(OrderRequest request)
        {
            var order = new Order
            {
                CustomerId = request.CustomerId,
                OrderDate = request.OrderDate,
                // Mapping OrderItems nếu cần
            };
            await _unitOfWork.RepositoryAsync<Order>().AddAsync(order);
            await _unitOfWork.SaveChangesAsync();
            return await GetByIdAsync(order.OrderId);
        }
    }
} 