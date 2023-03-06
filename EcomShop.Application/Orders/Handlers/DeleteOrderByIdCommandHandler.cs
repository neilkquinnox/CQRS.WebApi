using EcomShop.WebApi.Features.OrderFeatures.Commands;
using EcomShop.WebApi.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
namespace EcomShop.Application.Orders.Handlers
{
    public class DeleteOrderByIdCommandHandler : IRequestHandler<DeleteOrderByIdCommand, string>
    {
        private readonly IApplicationContext _context;
        public DeleteOrderByIdCommandHandler(IApplicationContext context)
        {
            _context = context;
        }
        public async Task<string> Handle(DeleteOrderByIdCommand command, CancellationToken cancellationToken)
        {
            var Order = await _context.Orders.Where(a => a.Id == command.Id.ToString()).FirstOrDefaultAsync();
            if (Order == null) return default;
            _context.Orders.Remove(Order);
            await _context.SaveChangesAsync();
            return Order.Id;
        }
    }
}
