using EcomShop.WebApi.Domain.Models;
using EcomShop.WebApi.Domain.ViewModel;
using EcomShop.WebApi.Infrastructure.Database;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EcomShop.Application.Orders.Commands
{
    public class CreateOrderCommand : IRequest<string>
    {
        public string Customer_ID { get; set; }
        //public decimal price { get; set; }
        public DateTime Date { get; set; }
        public List<OrderProductVM> orderProducts { get; set; }

        public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, string>
        {
            private readonly IApplicationContext _context;
            public CreateOrderCommandHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<string> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
            {
                var Order = new Order();

                Order.Id = Guid.NewGuid().ToString();
                Order.Customer_ID = command.Customer_ID.ToString();
                //Order.price = command.price;
                Order.Date = command.Date;
                _context.Orders.Add(Order);

                foreach (var orderitem in command.orderProducts)
                {
                    var orderdetail = new OrderProduct();
                    {
                        orderdetail.Order = Order;
                        orderdetail.Order_ID = Order.Id;
                        orderdetail.Product_ID = orderitem.Product_ID;
                        orderdetail.MembershipName = orderitem.MembershipName;
                        orderdetail.Quantity = orderitem.Quantity;
                        orderdetail.price = orderitem.price;
                    };
                    _context.OrderProducts.Add(orderdetail);

                    if (!string.IsNullOrEmpty(orderitem.MembershipName))
                    {
                        var CustomerMembership = new CustomerMembership();
                        CustomerMembership.CustomerId = command.Customer_ID;
                       _context.CustomerMemberships.Add(CustomerMembership);
                    }

                    await _context.SaveChangesAsync();

                }
                return Order.Id;
            }
        }
    }
}
