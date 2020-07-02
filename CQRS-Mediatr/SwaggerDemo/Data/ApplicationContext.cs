using Microsoft.EntityFrameworkCore;
using SwaggerDemo.Domain;
using System.Threading.Tasks;

namespace SwaggerDemo.Data
{
    public class ApplicationContext : DbContext, IApplicationContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
      : base(options)
        {

        }

        public ApplicationContext()
        {

        }
        public DbSet<Customer> Customers { get; set; }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }


    }
}
