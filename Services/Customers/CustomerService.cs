using DataAccessEF.Interfaces;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.DTOs;
using System.Linq;

namespace Services.Customers
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CustomerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<CustomerResponse>> GetAllAsync()
        {
            var entities = _unitOfWork.RepositoryAsync<Customer>().GetAll();
            return entities.Select(e => new CustomerResponse
            {
                Id = e.CustomerId,
                Name = e.FullName,
            });
        }
        public async Task<CustomerResponse> GetByIdAsync(int id)
        {
            var e = _unitOfWork.RepositoryAsync<Customer>().GetById(id);
            if (e == null) return null;
            return new CustomerResponse
            {
                Id = e.CustomerId,
                Name = e.FullName,
            };
        }
        public async Task<CustomerResponse> AddAsync(CustomerRequest request)
        {
            var entity = new Customer
            {
                FullName = request.Name,
            };
            await _unitOfWork.RepositoryAsync<Customer>().AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return new CustomerResponse
            {
                Id = entity.CustomerId,
                Name = entity.FullName,
            };
        }
        public async Task<bool> UpdateAsync(int id, CustomerRequest request)
        {
            var entity = _unitOfWork.RepositoryAsync<Customer>().GetById(id);
            if (entity == null) return false;
            entity.FullName = request.Name;
            _unitOfWork.RepositoryAsync<Customer>().Update(entity);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = _unitOfWork.RepositoryAsync<Customer>().GetById(id);
            if (entity == null) return false;
            _unitOfWork.RepositoryAsync<Customer>().Remove(entity);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
} 