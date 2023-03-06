using MediatR;

namespace EcomShop.Application.Products.Commands
{
    public class CreateProductCommand : IRequest<string>
    {
        public string Name { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        
        //public decimal BuyingPrice { get; set; }
        public decimal price { get; set; }
       
    }
}
