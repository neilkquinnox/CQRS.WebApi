using AutoMapper;
using EcomShop.Application.Customers.DTO;
using EcomShop.WebApi.Domain.Models;
using EcomShop.WebApi.Infrastructure.Database;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EcomShop.WebApi.Infrastructure.Features.CustomerFeatures.Queries
{
    public class GetCustomerByIdQuery : IRequest<CustomerDTO>
    {
        public string Id { get; set; }
      
    }

    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, CustomerDTO>
    {
        private readonly IApplicationContext _context;
        private readonly IMapper _mapper;
        public GetCustomerByIdQueryHandler(IApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<CustomerDTO> Handle(GetCustomerByIdQuery query, CancellationToken cancellationToken)
        {
            var Customer = _context.Customers.Where(a => a.Id == query.Id.ToString()).FirstOrDefault();
            if (Customer == null) return null;
            var customerDTO = _mapper.Map<CustomerDTO>(Customer);
            return customerDTO;

        }
    }
}
