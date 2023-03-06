using MediatR;

namespace EcomShop.WebApi.Features.OrderFeatures.Commands
{
    public class DeleteOrderByIdCommand : IRequest<string>
    {
        public int Id { get; set; }
       
    }
}
