using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.DTOs;

namespace Services.Products
{
    public interface IProductService
    {
        Task<IEnumerable<ProductResponse>> GetAllAsync();
        Task<ProductResponse> GetByIdAsync(int id);
        Task<ProductResponse> AddAsync(ProductRequest request);
        Task<bool> UpdateAsync(int id, ProductRequest request);
        Task<bool> DeleteAsync(int id);
    }
} 