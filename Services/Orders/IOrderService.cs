using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.DTOs;

namespace Services.Orders
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderResponse>> GetAllAsync();
        Task<OrderResponse> GetByIdAsync(int id);
        Task<OrderResponse> AddAsync(OrderRequest request);
        // Không cần update/xóa đơn hàng trong yêu cầu ban đầu
    }
} 