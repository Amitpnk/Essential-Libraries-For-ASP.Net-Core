using MediatR;
using SwaggerDemo.Data;
using SwaggerDemo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SwaggerDemo.Features.CustomerFeatures.Comands
{
    public class CustomerViewModel : IRequest<int>
    {
        public string CustomerName { get; set; }
        public string CustomerCode { get; set; }
    }

    public class CreateProductCommandHandler : IRequestHandler<CustomerViewModel, int>
    {
        private readonly IApplicationContext _context;
        public CreateProductCommandHandler(IApplicationContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CustomerViewModel request, CancellationToken cancellationToken)
        {
            var customer = new Customer();
            customer.CustomerCode = request.CustomerCode;
            customer.CustomerName = request.CustomerName;

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer.Id;
        }
    }
}
