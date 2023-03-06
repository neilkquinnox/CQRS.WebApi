using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcomShop.WebApi.Domain.Models
{
    public class Order
    {
        public string Id { get; set; }
        public string Customer_ID { get; set; }      
        public DateTime Date { get; set; }
        public decimal price { get; set; }

        public List<OrderProduct> orderProducts;

    }
}
