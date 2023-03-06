using EcomShop.WebApi.Infrastructure.Database;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EcomShop.Application.Customers.Commands
{
    public class UpdateCustomerCommand : IRequest<string>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
       
    }
}
