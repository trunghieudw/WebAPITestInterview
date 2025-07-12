using System;
using System.Collections.Generic;

namespace Domain.DTOs
{
    public class OrderResponse
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderItemResponse> Items { get; set; }
        public decimal TotalAmount { get; set; }
    }
} 