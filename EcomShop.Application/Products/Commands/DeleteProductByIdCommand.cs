using MediatR;

namespace EcomShop.WebApi.Features.ProductFeatures.Commands
{
    public class DeleteProductByIdCommand : IRequest<string>
    {
        public int Id { get; set; }
       
    }
}
