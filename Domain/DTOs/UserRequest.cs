using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class UserRequest
    {
        [MaxLength(10)]
        public string Username { get; set; }
        public string Pw { get; set; }
        public string Phonenumber { get; set; }
        public int Customerid { get; set; }
    }
}
