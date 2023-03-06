using EcomShop.WebApi.Domain.Models;
using EcomShop.WebApi.Infrastructure.Database;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EcomShop.WebApi.Application.Features.ProductFeatures.Commands
{
    public class CreateProductCommand : IRequest<string>
    {
        public string Name { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        
        //public decimal BuyingPrice { get; set; }
        public decimal price { get; set; }
        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, string>
        {
            private readonly IApplicationContext _context;
            public CreateProductCommandHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<string> Handle(CreateProductCommand command, CancellationToken cancellationToken)
            {
                var product = new Product();
                product.Id = Guid.NewGuid().ToString();
                product.Barcode = command.Barcode;
                product.Name = command.Name;
                product.price = command.price;
                product.Description = command.Description;
                product.Category = command.Category;
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return product.Id;
            }
        }
    }
}
