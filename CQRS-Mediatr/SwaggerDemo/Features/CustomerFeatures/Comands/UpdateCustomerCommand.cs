using MediatR;
using SwaggerDemo.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SwaggerDemo.Features.CustomerFeatures.Comands
{
    public class UpdateCustomerCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerCode { get; set; }

        public class UpdateCustomerCommanddHandler : IRequestHandler<UpdateCustomerCommand, int>
        {
            private readonly IApplicationContext _context;
            public UpdateCustomerCommanddHandler(IApplicationContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
            {
                var customer = _context.Customers.Where(a => a.Id == request.Id).FirstOrDefault();

                if (customer == null)
                {
                    return default;
                }
                else
                {
                    customer.CustomerCode = request.CustomerCode;
                    customer.CustomerName = request.CustomerName;
                    _context.Customers.Update(customer);

                    await _context.SaveChangesAsync();
                    return customer.Id;
                }
            }
        }
    }
}
