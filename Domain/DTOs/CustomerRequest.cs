using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class CustomerRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int CustomerType { get; set; }
    }
}
