using EcomShop.Application.Products.Commands;
using EcomShop.WebApi.Domain.Models;
using EcomShop.WebApi.Infrastructure.Database;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;


namespace EcomShop.Application.Products.Handlers
{
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
