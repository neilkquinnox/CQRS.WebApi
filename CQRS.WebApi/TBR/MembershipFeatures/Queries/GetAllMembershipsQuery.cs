using EcomShop.WebApi.Domain.Models;
using EcomShop.WebApi.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EcomShop.WebApi.Application.Features.MembershipFeatures.Queries
{
    public class GetAllMembershipsQuery : IRequest<IEnumerable<Membership>>
    {

        public class GetAllMembershipsQueryHandler : IRequestHandler<GetAllMembershipsQuery,IEnumerable<Membership>>
        {
            private readonly IApplicationContext _context;
            public GetAllMembershipsQueryHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Membership>> Handle(GetAllMembershipsQuery query, CancellationToken cancellationToken)
            {
                var MembershipList = await _context.Memberships.ToListAsync();
                if (MembershipList == null)
                {
                    return null;
                }
                return MembershipList.AsReadOnly();
            }
        }
    }
}
