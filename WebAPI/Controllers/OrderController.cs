using Microsoft.AspNetCore.Mvc;
using Services.Orders;
using Domain.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq; // Added missing import for .Where()

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // [GET] /api/orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderResponse>>> GetAll(
            [FromQuery] DateTime? fromDate = null,
            [FromQuery] DateTime? toDate = null,
            [FromQuery] int? customerId = null)
        {
            var orders = await _orderService.GetAllAsync();
            
            // Filter theo ngày
            if (fromDate.HasValue)
            {
                orders = orders.Where(o => o.OrderDate >= fromDate.Value);
            }
            if (toDate.HasValue)
            {
                orders = orders.Where(o => o.OrderDate <= toDate.Value);
            }
            
            // Filter theo customer
            if (customerId.HasValue)
            {
                orders = orders.Where(o => o.CustomerId == customerId.Value);
            }
            
            return Ok(orders);
        }

        // [GET] /api/orders/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderResponse>> GetById(int id)
        {
            var order = await _orderService.GetByIdAsync(id);
            if (order == null)
                return NotFound();
            return Ok(order);
        }

        // [POST] /api/orders
        [HttpPost]
        public async Task<ActionResult<OrderResponse>> CreateOrder([FromBody] OrderRequest order)
        {
            var result = await _orderService.AddAsync(order);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }
    }
} 