using EcomShop.WebApi.Domain.Models;
using EcomShop.WebApi.Infrastructure.Database;
using EcomShop.WebApi.Infrastructure.Features.OrderFeatures.Queries;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EcomShop.Application.Orders.Handlers
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, Order>
    {
        private readonly IApplicationContext _context;
        public GetOrderByIdQueryHandler(IApplicationContext context)
        {
            _context = context;
        }
        public async Task<Order> Handle(GetOrderByIdQuery query, CancellationToken cancellationToken)
        {

            var Order = _context.Orders.Where(a => a.Id == query.Id.ToString()).FirstOrDefault();
            List<OrderProduct> objorderProducts = new List<OrderProduct>();
            objorderProducts = _context.OrderProducts.Where(a => a.Order_ID == query.Id.ToString()).ToList();
            Order.orderProducts = objorderProducts;
            if (Order == null) return null;
            return Order;
        }
    }
}
