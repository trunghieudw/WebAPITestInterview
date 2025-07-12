using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.DTOs;

namespace Services.OrderItems
{
    public interface IOrderItemService
    {
        Task<IEnumerable<OrderItemResponse>> GetAllByOrderIdAsync(int orderId);
        Task<OrderItemResponse> AddAsync(int orderId, OrderItemRequest request);
    }
} 