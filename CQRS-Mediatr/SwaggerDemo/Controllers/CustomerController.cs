using MediatR;
using Microsoft.AspNetCore.Mvc;
using SwaggerDemo.Data;
using SwaggerDemo.Domain;
using SwaggerDemo.Features.CustomerFeatures.Comands;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
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

      
        //[HttpGet]
        //public ActionResult<IEnumerable<Customer>> Get()
        //{
        //    var customers = _context.Customers.ToList();

        //    return Ok(customers);
        //}


        ///// <summary>
        ///// Get customer detail by id
        ///// </summary>
        ///// <param name="id">This id is unique/primary key of customer </param>
        ///// <returns>Customer details with id, customername and cutomer code fields</returns>
        //[HttpGet]
        //[Route("{id}", Name = "GetCustomer")]
        //public ActionResult<Customer> Get(int id)
        //{
        //    var customers = _context.Customers.Find(id);

        //    if (customers == null)
        //    {
        //        NotFound();
        //    }

        //    return Ok(customers);
        //}

        // POST api/<CustomerController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CustomerViewModel customer)
        {
            //_context.Customers.Add(customer);
            //_context.SaveChanges();

            //return CreatedAtRoute("GetCustomer", new { id = customer.Id }, customer);

            return  Ok(await Mediator.Send(customer));

        }

        //// PUT api/<CustomerController>/5
        //[HttpPut("{id}")]
        //public IActionResult Put(int id, [FromBody] Customer customer)
        //{
        //    var customers = _context.Customers.First(a => a.Id == id);

        //    if (customers == null)
        //    {
        //        NotFound();
        //    }

        //    // TODO- Use AutoMapper
        //    customers.CustomerCode = customer.CustomerCode;
        //    customers.CustomerName = customer.CustomerName;

        //    _context.Customers.Update(customers);
        //    _context.SaveChanges();

        //    return Ok(customers);

        //}

        //[HttpDelete]
        //[Route("{customerId}")]
        //public ActionResult<Customer> Delete(int customerId)
        //{
        //    var customers = _context.Customers.Find(customerId);

        //    if (customers == null)
        //    {
        //        NotFound();
        //    }
        //    _context.Customers.Remove(customers);
        //    _context.SaveChanges();

        //    return NoContent();

        //}
    }
}
