using EcomShop.Application.Customers.Commands;
using EcomShop.WebApi.Infrastructure.Database;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
namespace EcomShop.Application.Customers.Handlers
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, string>
    {
        private readonly IApplicationContext _context;
        public UpdateCustomerCommandHandler(IApplicationContext context)
        {
            _context = context;
        }
        public async Task<string> Handle(UpdateCustomerCommand command, CancellationToken cancellationToken)
        {
            var Customer = _context.Customers.Where(a => a.Id == command.Id.ToString()).FirstOrDefault();

            if (Customer == null)
            {
                return default;
            }
            else
            {
                Customer.Name = command.Name;
                Customer.Email = command.Email;
                Customer.Phone = command.Phone;
                await _context.SaveChangesAsync();
                return Customer.Id;
            }
        }
    }
}
