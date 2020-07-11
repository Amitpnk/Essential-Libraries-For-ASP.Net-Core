using Microsoft.AspNetCore.Mvc;
using JWTAuthentication.Data;
using JWTAuthentication.Domain;
using System.Collections.Generic;
using System.Linq;

namespace JWTAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "OpenAPISpecificationCustomer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerContext _context;

        public CustomerController(CustomerContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all customer details
        /// </summary>
        /// <returns>All customer details with id, customername and cutomer code fields</returns>
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> Get()
        {
            var customers = _context.Customers.ToList();

            return Ok(customers);
        }


        /// <summary>
        /// Get customer detail by id
        /// </summary>
        /// <param name="id">This id is unique/primary key of customer </param>
        /// <returns>Customer details with id, customername and cutomer code fields</returns>
        [HttpGet]
        [Route("{id}", Name = "GetCustomer")]
        public ActionResult<Customer> Get(int id)
        {
            var customers = _context.Customers.Find(id);

            if (customers == null)
            {
                NotFound();
            }

            return Ok(customers);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public IActionResult Post([FromBody] Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();

            return CreatedAtRoute("GetCustomer", new { id = customer.Id }, customer);


        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Customer customer)
        {
            var customers = _context.Customers.First(a => a.Id == id);

            if (customers == null)
            {
                NotFound();
            }

            // TODO- Use AutoMapper
            customers.CustomerCode = customer.CustomerCode;
            customers.CustomerName = customer.CustomerName;

            _context.Customers.Update(customers);
            _context.SaveChanges();

            return Ok(customers);

        }

        [HttpDelete]
        [Route("{customerId}")]
        public ActionResult<Customer> Delete(int customerId)
        {
            var customers = _context.Customers.Find(customerId);

            if (customers == null)
            {
                NotFound();
            }
            _context.Customers.Remove(customers);
            _context.SaveChanges();

            return NoContent();

        }
    }
}
