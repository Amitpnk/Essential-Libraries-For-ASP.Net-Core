using Microsoft.EntityFrameworkCore;
using SwaggerDemo.Domain;

namespace SwaggerDemo.Data
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options)
      : base(options)
        {

        }

        public CustomerContext()
        {

        }
        public DbSet<Customer> Customers { get; set; }
    }
}
