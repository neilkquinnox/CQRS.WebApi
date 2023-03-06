using EcomShop.WebApi.Domain.Models;
using EcomShop.WebApi.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EcomShop.WebApi.Application.Features.OrderFeatures.Queries
{
    public class GetAllOrdersQuery : IRequest<IEnumerable<Order>>
    {

        public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery,IEnumerable<Order>>
        {
            private readonly IApplicationContext _context;
            public GetAllOrdersQueryHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Order>> Handle(GetAllOrdersQuery query, CancellationToken cancellationToken)
            {
                var OrderList = await _context.Orders.ToListAsync();
                if (OrderList == null)
                {
                    return null;
                }
                return OrderList.AsReadOnly();
            }
        }
    }
}
