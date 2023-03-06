using EcomShop.WebApi.Infrastructure.Database;
using MediatR;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EcomShop.WebApi.Features.MembershipFeatures.Commands
{
    public class UpdateMembershipCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
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
}
