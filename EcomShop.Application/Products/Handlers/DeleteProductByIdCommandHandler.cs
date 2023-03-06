using EcomShop.WebApi.Features.ProductFeatures.Commands;
using EcomShop.WebApi.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EcomShop.Application.Products.Handlers
{
    public class DeleteProductByIdCommandHandler : IRequestHandler<DeleteProductByIdCommand, string>
    {
        private readonly IApplicationContext _context;
        public DeleteProductByIdCommandHandler(IApplicationContext context)
        {
            _context = context;
        }
        public async Task<string> Handle(DeleteProductByIdCommand command, CancellationToken cancellationToken)
        {
            var product = await _context.Products.Where(a => a.Id == command.Id.ToString()).FirstOrDefaultAsync();
            if (product == null) return default;
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return product.Id;
        }
    }
}
