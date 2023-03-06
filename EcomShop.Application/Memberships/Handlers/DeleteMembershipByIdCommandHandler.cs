using EcomShop.WebApi.Features.MembershipFeatures.Commands;
using EcomShop.WebApi.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading;
using System.Threading.Tasks;

namespace EcomShop.Application.Memberships.Handlers
{
    public class DeleteMembershipByIdCommandHandler : IRequestHandler<DeleteMembershipByIdCommand, int>
    {
        private readonly IApplicationContext _context;
        public DeleteMembershipByIdCommandHandler(IApplicationContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(DeleteMembershipByIdCommand command, CancellationToken cancellationToken)
        {
            var Membership = await _context.Memberships.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
            if (Membership == null) return default;
            _context.Memberships.Remove(Membership);
            await _context.SaveChangesAsync();
            return Membership.Id;
        }
    }
}
