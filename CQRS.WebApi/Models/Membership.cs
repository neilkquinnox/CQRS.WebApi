using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcomShop.WebApi.Domain.Models
{
    public class Membership
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }  

    }
}
