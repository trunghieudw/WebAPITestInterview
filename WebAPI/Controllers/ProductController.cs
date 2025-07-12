using Microsoft.AspNetCore.Mvc;
using Services.Products;
using Domain.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // [GET] /api/products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductResponse>>> GetAll()
        {
            var products = await _productService.GetAllAsync();
            return Ok(products);
        }

        // [GET] /api/products/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductResponse>> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        // [POST] /api/products
        [HttpPost]
        public async Task<ActionResult<ProductResponse>> AddProduct([FromBody] ProductRequest product)
        {
            var result = await _productService.AddAsync(product);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        // [PUT] /api/products/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProductRequest product)
        {
            var updated = await _productService.UpdateAsync(id, product);
            if (!updated)
                return NotFound();
            return NoContent();
        }

        // [DELETE] /api/products/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _productService.DeleteAsync(id);
            if (!deleted)
                return NotFound();
            return NoContent();
        }
    }
} 