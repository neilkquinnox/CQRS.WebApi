using EcomShop.WebApi.Domain.Models;
using MediatR;

namespace EcomShop.WebApi.Infrastructure.Features.ProductFeatures.Queries
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public string Id { get; set; }
        
    }
}
