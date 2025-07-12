using DataAccessEF.Interfaces;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.DTOs;
using System.Linq;

namespace Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<ProductResponse>> GetAllAsync()
        {
            var entities = _unitOfWork.RepositoryAsync<Product>().GetAll();
            return entities.Select(e => new ProductResponse
            {
                Id = e.ProductId,
                Name = e.Name,
                Price = e.Price,
            });
        }
        public async Task<ProductResponse> GetByIdAsync(int id)
        {
            var e = _unitOfWork.RepositoryAsync<Product>().GetById(id);
            if (e == null) return null;
            return new ProductResponse
            {
                Id = e.ProductId,
                Name = e.Name,
                Price = e.Price,
            };
        }
        public async Task<ProductResponse> AddAsync(ProductRequest request)
        {
            var entity = new Product
            {
                Name = request.Name,
                Price = request.Price,
            };
            await _unitOfWork.RepositoryAsync<Product>().AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return new ProductResponse
            {
                Id = entity.ProductId,
                Name = entity.Name,
                Price = entity.Price,
            };
        }
        public async Task<bool> UpdateAsync(int id, ProductRequest request)
        {
            var entity = _unitOfWork.RepositoryAsync<Product>().GetById(id);
            if (entity == null) return false;
            entity.Name = request.Name;
            entity.Price = request.Price;
            _unitOfWork.RepositoryAsync<Product>().Update(entity);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = _unitOfWork.RepositoryAsync<Product>().GetById(id);
            if (entity == null) return false;
            _unitOfWork.RepositoryAsync<Product>().Remove(entity);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
} 