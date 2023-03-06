using EcomShop.WebApi.Features.MembershipFeatures.Commands;
using EcomShop.WebApi.Infrastructure.Database;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EcomShop.Application.Memberships.Handlers
{
    public class UpdateMembershipCommandHandler : IRequestHandler<UpdateMembershipCommand, int>
    {
        private readonly IApplicationContext _context;
        public UpdateMembershipCommandHandler(IApplicationContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(UpdateMembershipCommand command, CancellationToken cancellationToken)
        {
            var Membership = _context.Memberships.Where(a => a.Id == command.Id).FirstOrDefault();

            if (Membership == null)
            {
                return default;
            }
            else
            {
                Membership.Name = command.Name;
                Membership.Description = command.Description;
                Membership.Price = command.Price;
                await _context.SaveChangesAsync();
                return Membership.Id;
            }
        }
    }
}
