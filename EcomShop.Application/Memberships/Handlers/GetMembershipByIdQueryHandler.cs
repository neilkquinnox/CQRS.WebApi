using EcomShop.WebApi.Domain.Models;
using EcomShop.WebApi.Infrastructure.Database;
using EcomShop.WebApi.Infrastructure.Features.MembershipFeatures.Queries;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EcomShop.Application.Memberships.Handlers
{
    public class GetMembershipByIdQueryHandler : IRequestHandler<GetMembershipByIdQuery, Membership>
    {
        private readonly IApplicationContext _context;
        public GetMembershipByIdQueryHandler(IApplicationContext context)
        {
            _context = context;
        }
        public async Task<Membership> Handle(GetMembershipByIdQuery query, CancellationToken cancellationToken)
        {
            var Membership = _context.Memberships.Where(a => a.Id == query.Id).FirstOrDefault();
            if (Membership == null) return null;
            return Membership;
        }
    }
}
