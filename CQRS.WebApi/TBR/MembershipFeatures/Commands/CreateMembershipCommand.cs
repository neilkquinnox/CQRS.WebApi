using EcomShop.WebApi.Domain.Models;
using EcomShop.WebApi.Infrastructure.Database;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EcomShop.WebApi.Application.Features.MembershipFeatures.Commands
{
    public class CreateMembershipCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }

        public class CreateMembershipCommandHandler : IRequestHandler<CreateMembershipCommand, int>
        {
            private readonly IApplicationContext _context;
            public CreateMembershipCommandHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateMembershipCommand command, CancellationToken cancellationToken)
            {
                var Membership = new Membership();
                Membership.Name = command.Name;
                Membership.Description = command.Description;
                Membership.Price = command.Price;              
                _context.Memberships.Add(Membership);
                await _context.SaveChangesAsync();
                return Membership.Id;
                                      
        
        }
        }
    }
}
