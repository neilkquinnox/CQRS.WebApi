using EcomShop.Application.Customers.Commands;
using EcomShop.WebApi.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading;
using System.Threading.Tasks;


namespace EcomShop.Application.Customers.Handlers
{
    public class DeleteCustomerByIdCommandHandler : IRequestHandler<DeleteCustomerByIdCommand, string>
    {
        private readonly IApplicationContext _context;
        public DeleteCustomerByIdCommandHandler(IApplicationContext context)
        {
            _context = context;
        }
        public async Task<string> Handle(DeleteCustomerByIdCommand command, CancellationToken cancellationToken)
        {
            var Customer = await _context.Customers.Where(a => a.Id == command.Id.ToString()).FirstOrDefaultAsync();
            if (Customer == null) return default;
            _context.Customers.Remove(Customer);
            await _context.SaveChangesAsync();
            return Customer.Id;
        }
    }
}
