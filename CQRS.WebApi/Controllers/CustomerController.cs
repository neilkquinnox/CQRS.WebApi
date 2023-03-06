using EcomShop.Infrastructure.Logging;
using EcomShop.WebApi.Application.Features.CustomerFeatures.Commands;
using EcomShop.WebApi.Application.Features.CustomerFeatures.Queries;
using EcomShop.WebApi.Features.CustomerFeatures.Commands;
using EcomShop.WebApi.Infrastructure.Features.CustomerFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace EcomShop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private IMediator _mediator;
        private readonly ILoggerManager _logger;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        public CustomerController(ILoggerManager logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Creates a New Customer.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateCustomerCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        /// <summary>
        /// Gets all Customers.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInfo("Here is info message from the controller.");
            var customers = await Mediator.Send(new GetAllCustomersQuery());
            return Ok(customers);
            //return Ok(await Mediator.Send(new GetAllCustomersQuery()));
        }
        /// <summary>
        /// Gets Customer Entity by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            return Ok(await Mediator.Send(new GetCustomerByIdQuery { Id = id }));
        }
        /// <summary>
        /// Deletes Customer Entity based on Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteCustomerByIdCommand { Id = id }));
        }
        /// <summary>
        /// Updates the Customer Entity based on Id.   
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateCustomerCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }
    }
}