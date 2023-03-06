using EcomShop.WebApi.Features.OrderFeatures.Commands;
using EcomShop.WebApi.Infrastructure.Database;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EcomShop.Application.Orders.Handlers
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, string>
    {
        private readonly IApplicationContext _context;
        public UpdateOrderCommandHandler(IApplicationContext context)
        {
            _context = context;
        }
        public async Task<string> Handle(UpdateOrderCommand command, CancellationToken cancellationToken)
        {
            var Order = _context.Orders.Where(a => a.Id == command.Id.ToString()).FirstOrDefault();

            if (Order == null)
            {
                return default;
            }
            else
            {
                Order.Customer_ID = command.Customer_ID;
                Order.price = command.price;
                Order.Date = command.Date;
                await _context.SaveChangesAsync();
                return Order.Id;
            }
        }
    }
}
