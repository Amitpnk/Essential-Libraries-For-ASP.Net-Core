using MediatR;
using SwaggerDemo.Data;
using SwaggerDemo.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SwaggerDemo.Features.CustomerFeatures.Comands
{
    public class CreateCustomerCommand : IRequest<int>
    {
        public string CustomerName { get; set; }
        public string CustomerCode { get; set; }

        public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, int>
        {
            private readonly IApplicationContext _context;
            public CreateCustomerCommandHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
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
}
