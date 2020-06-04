using Microsoft.EntityFrameworkCore;
using SwaggerDemo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
