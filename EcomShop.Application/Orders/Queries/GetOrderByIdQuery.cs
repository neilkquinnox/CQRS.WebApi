using EcomShop.WebApi.Domain.Models;
using MediatR;

namespace EcomShop.WebApi.Infrastructure.Features.OrderFeatures.Queries
{
    public class GetOrderByIdQuery : IRequest<Order>
    {
        public string Id { get; set; }
       
    }
}
