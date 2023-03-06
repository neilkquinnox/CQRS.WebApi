using EcomShop.WebApi.Domain.Models;
using MediatR;

namespace EcomShop.WebApi.Infrastructure.Features.MembershipFeatures.Queries
{
    public class GetMembershipByIdQuery : IRequest<Membership>
    {
        public int Id { get; set; }
      
    }
}
