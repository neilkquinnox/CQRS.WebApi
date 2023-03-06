using EcomShop.WebApi.Domain.Models;
using EcomShop.WebApi.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EcomShop.WebApi.Application.Features.CustomerFeatures.Queries
{
    public class GetAllCustomersQuery : IRequest<IEnumerable<Customer>>
    {

        public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery,IEnumerable<Customer>>
        {
            private readonly IApplicationContext _context;
            public GetAllCustomersQueryHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Customer>> Handle(GetAllCustomersQuery query, CancellationToken cancellationToken)
            {
                var CustomerList = await _context.Customers.ToListAsync();
                if (CustomerList == null)
                {
                    return null;
                }
                return CustomerList.AsReadOnly();
            }
        }
    }
}
