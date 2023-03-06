using MediatR;

namespace EcomShop.WebApi.Features.MembershipFeatures.Commands
{
    public class DeleteMembershipByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
        
    }
}
