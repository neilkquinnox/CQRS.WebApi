using EcomShop.WebApi.Domain.Models;
using EcomShop.WebApi.Infrastructure.Database;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EcomShop.WebApi.Application.Features.CustomerFeatures.Commands
{
    public class CreateCustomerCommand : IRequest<string>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }                  
       
        public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, string>
        {
            private readonly IApplicationContext _context;
            public CreateCustomerCommandHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<string> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
            {
                var Customer = new Customer();
                Customer.Id = Guid.NewGuid().ToString();
                Customer.Name = command.Name;
                Customer.Email = command.Email;
                Customer.Phone = command.Phone;              
                _context.Customers.Add(Customer);
                await _context.SaveChangesAsync();
                return Customer.Id;                                      
        
        }
        }
    }
}
