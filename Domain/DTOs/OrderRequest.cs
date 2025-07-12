using System;
using System.Collections.Generic;

namespace Domain.DTOs
{
    public class OrderRequest
    {
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderItemRequest> Items { get; set; }
    }
} 