using MediatR;

namespace EcomShop.Application.Memberships.Commands
{
    public class CreateMembershipCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }    
    }
}
