using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using SwaggerDemo.Domain;
using SwaggerDemo.Features.CustomerFeatures.Comands;
using SwaggerDemo.Features.CustomerFeatures.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SwaggerDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "OpenAPISpecificationCustomer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetAsync()
        {
            return Ok(await Mediator.Send(new GetAllCustomerQuery()));
        }

        [HttpGet]
        [Route("{id}", Name = "GetCustomer")]
        public async Task<ActionResult<Customer>> GetAsync(int id)
        {
            var customers = await Mediator.Send(new GetCustomerByIdQuery { Id = id });

            if (customers == null)
            {
                NotFound();
            }

            return Ok(customers);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCustomerCommand command)
        {
            var customerId = await Mediator.Send(command);
            return CreatedAtRoute("GetCustomer", new { id = customerId });
        }

        //// PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateCustomerCommand command)
        {
            if (id != command.Id)
            {
                return NotFound();
            }
            return Ok(await Mediator.Send(command));

        }

        [HttpDelete]
        [Route("{customerId}")]
        public async Task<IActionResult> Delete(int customerId)
        {
            //var customers = _context.Customers.Find(customerId);

            // if (customers == null)
            // {
            //     NotFound();
            // }
            await Mediator.Send(new DeleteCustomerByIdCommand { Id = customerId });

            return NoContent();





        }
    }
}
