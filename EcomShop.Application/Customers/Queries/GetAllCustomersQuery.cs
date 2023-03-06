using EcomShop.WebApi.Domain.Models;
using MediatR;
using System.Collections.Generic;

namespace EcomShop.Application.Customers.Queries
{
    public class GetAllCustomersQuery : IRequest<IEnumerable<Customer>>
    {
      
    }
}
