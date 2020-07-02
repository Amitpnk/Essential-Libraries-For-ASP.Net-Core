using Microsoft.EntityFrameworkCore;
using SwaggerDemo.Domain;
using System.Threading.Tasks;

namespace SwaggerDemo.Data
{
    public interface IApplicationContext
    {
        DbSet<Customer> Customers { get; set; }
        Task<int> SaveChangesAsync();
    }
}