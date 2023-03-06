using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcomShop.WebApi.Domain.Models
{
    public class OrderProduct
    {
        public int Id { get; set; }
        public string Order_ID { get; set; }
        public string Product_ID { get; set; }
        public decimal price { get; set; }
        public string MembershipName { get; set; }
        public int Quantity  { get; set; }    
        public Order Order { get; set; }

     }
}
