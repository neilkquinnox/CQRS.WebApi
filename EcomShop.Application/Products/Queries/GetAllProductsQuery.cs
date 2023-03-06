using EcomShop.WebApi.Domain.Models;
using MediatR;
using System.Collections.Generic;

namespace EcomShop.Application.Products.Queries
{
    public class GetAllProductsQuery : IRequest<IEnumerable<Product>>
    {

       
    }
}
