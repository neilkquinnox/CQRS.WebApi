using MediatR;

namespace EcomShop.Application.Customers.Commands
{
    public class DeleteCustomerByIdCommand : IRequest<string>
    {
        public int Id { get; set; }      
    }
}
