using JWTAuthentication.Domain;
using JWTAuthentication.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JWTAuthentication.Data
{
    public class CustomerContext : IdentityDbContext<ApplicationUser>
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
