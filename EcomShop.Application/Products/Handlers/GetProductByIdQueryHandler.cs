using EcomShop.WebApi.Domain.Models;
using EcomShop.WebApi.Infrastructure.Database;
using EcomShop.WebApi.Infrastructure.Features.ProductFeatures.Queries;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
namespace EcomShop.Application.Products.Handlers
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly IApplicationContext _context;
        public GetProductByIdQueryHandler(IApplicationContext context)
        {
            _context = context;
        }
        public async Task<Product> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            var product = _context.Products.Where(a => a.Id == query.Id.ToString()).FirstOrDefault();
            if (product == null) return null;
            return product;
        }
    }
}
