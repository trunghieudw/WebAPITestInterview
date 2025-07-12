using DataAccessEF.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Services.Customers;
using Domain.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // [GET] /api/customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerResponse>>> GetAll()
        {
            var customers = await _customerService.GetAllAsync();
            return Ok(customers);
        }

        // [GET] /api/customers/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerResponse>> GetById(int id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            if (customer == null)
                return NotFound();
            return Ok(customer);
        }

        // [POST] /api/customers
        [HttpPost]
        public async Task<ActionResult<CustomerResponse>> AddCustomer([FromBody] CustomerRequest customer)
        {
            var result = await _customerService.AddAsync(customer);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        // [PUT] /api/customers/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CustomerRequest customer)
        {
            var updated = await _customerService.UpdateAsync(id, customer);
            if (!updated)
                return NotFound();
            return NoContent();
        }

        // [DELETE] /api/customers/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _customerService.DeleteAsync(id);
            if (!deleted)
                return NotFound();
            return NoContent();
        }
    }
}
