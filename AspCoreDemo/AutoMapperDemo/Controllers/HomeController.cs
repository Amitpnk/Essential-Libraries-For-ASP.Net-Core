using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AutoMapperDemo.Models;
using AutoMapper;

namespace AutoMapperDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMapper _mapper;
        public HomeController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            Customer customerdetails = new Customer()
            {
                CustomerId = 1,
                CompanyName = "ABC",
                Address = "Banaglore",
                Phone = "000",
                FirstName = "Shwetha",
                MiddleName = "Amit",
                LastName = "Naik",
                City = "Bangalore",
                Country = "India",
                Pincode = "560091"
            };
            var customerModel = _mapper.Map<CustomerModel>(customerdetails);
            var fullname = customerModel.FullName;
            var address = customerModel.City;
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
