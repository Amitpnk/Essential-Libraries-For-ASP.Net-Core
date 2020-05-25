using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CustomerEFCore.API.Model;
using CustomerEFCore.Repository.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace CustomerEFCore.API.Controllers
{
    [Route("api/Customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepo;
        private readonly IMapper _mapper;
        public CustomerController(IMapper mapper, ICustomerRepository customerRepository)
        {
            _customerRepo = customerRepository;
            _mapper = mapper;
        }

        // GET: api/Customer
        [HttpGet]
        public async Task<IEnumerable<CustomerModel>> Get()
        {
            try
            {
                var result = await _customerRepo.GetAllCustomersAsync();

                var mappedResult = _mapper.Map<IEnumerable<CustomerModel>>(result);
                return mappedResult;
            }
            catch (Exception)
            {

                throw;
            }



        }


    }
}
