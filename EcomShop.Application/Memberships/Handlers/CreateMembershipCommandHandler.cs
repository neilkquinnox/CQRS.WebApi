using EcomShop.Application.Memberships.Commands;
using EcomShop.WebApi.Domain.Models;
using EcomShop.WebApi.Infrastructure.Database;
using MediatR;
using System.Threading;
using System.Threading.Tasks;


namespace EcomShop.Application.Memberships.Handlers
{
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
