using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.DTOs;

namespace Services.Customers
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerResponse>> GetAllAsync();
        Task<CustomerResponse> GetByIdAsync(int id);
        Task<CustomerResponse> AddAsync(CustomerRequest request);
        Task<bool> UpdateAsync(int id, CustomerRequest request);
        Task<bool> DeleteAsync(int id);
    }
} 