using DataAccessEF.Interfaces;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.DTOs;
using System.Linq;

namespace Services.OrderItems
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderItemService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<OrderItemResponse>> GetAllByOrderIdAsync(int orderId)
        {
            var items = _unitOfWork.RepositoryAsync<OrderItem>().GetAll();
            return items.Where(i => i.OrderId == orderId).Select(oi => new OrderItemResponse
            {
                Id = oi.OrderItemId,
                ProductId = oi.ProductId,
                Quantity = oi.Quantity,
                UnitPrice = oi.UnitPrice,
            });
        }
        public async Task<OrderItemResponse> AddAsync(int orderId, OrderItemRequest request)
        {
            var entity = new OrderItem
            {
                OrderId = orderId,
                ProductId = request.ProductId,
                Quantity = request.Quantity,
                UnitPrice = request.UnitPrice,
            };
            await _unitOfWork.RepositoryAsync<OrderItem>().AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return new OrderItemResponse
            {
                Id = entity.OrderItemId,
                ProductId = entity.ProductId,
                Quantity = entity.Quantity,
                UnitPrice = entity.UnitPrice,
            };
        }
    }
} 