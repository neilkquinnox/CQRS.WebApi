using EcomShop.WebApi.Domain.Models;
using MediatR;
using System.Collections.Generic;

namespace EcomShop.Application.Orders.Queries
{
    public class GetAllOrdersQuery : IRequest<IEnumerable<Order>>
    {

      
    }
}
