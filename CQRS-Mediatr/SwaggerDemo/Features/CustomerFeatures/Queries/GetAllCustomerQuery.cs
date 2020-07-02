using MediatR;
using Microsoft.EntityFrameworkCore;
using SwaggerDemo.Data;
using SwaggerDemo.Domain;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SwaggerDemo.Features.CustomerFeatures.Queries
{
    public class GetAllCustomerQuery : IRequest<IEnumerable<Customer>>
    {
        public class GetAllProductsQueryHandler : IRequestHandler<GetAllCustomerQuery, IEnumerable<Customer>>
        {
            private readonly IApplicationContext _context;
            public GetAllProductsQueryHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Customer>> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
            {
                var productList = await _context.Customers.ToListAsync();
                if (productList == null)
                {
                    return null;
                }
                return productList.AsReadOnly();
            }
        }
    }
}
