using MediatR;

namespace EcomShop.Application.Customers.Commands
{
    public class CreateCustomerCommand : IRequest<string>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }   
    } 
}
