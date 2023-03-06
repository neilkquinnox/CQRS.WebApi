using EcomShop.Application.Customers.DTO;
using EcomShop.WebApi.Domain.Models;
using MediatR;

namespace EcomShop.Application.Customers.Queries
{
    public class GetCustomerByIdQuery : IRequest<CustomerDTO>
    {
        public string Id { get; set; }

    }
}
