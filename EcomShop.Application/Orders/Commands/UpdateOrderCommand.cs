using MediatR;
using System;

namespace EcomShop.WebApi.Features.OrderFeatures.Commands
{
    public class UpdateOrderCommand : IRequest<string>
    {
        public string Id { get; set; }
        public string Customer_ID { get; set; }
        public decimal price { get; set; }
        public DateTime Date { get; set; }

        
    }
}
