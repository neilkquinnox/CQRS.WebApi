using System;
using System.Collections.Generic;
using System.Text;

namespace EcomShop.Application.Customers.DTO
{
    public class CustomerDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public string Phone { get; set; }

    }
}
