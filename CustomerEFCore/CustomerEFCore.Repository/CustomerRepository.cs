using CustomerEFCore.Data;
using CustomerEFCore.Domain;
using CustomerEFCore.Repository.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerEFCore.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerContext _context;

        public CustomerRepository(CustomerContext context)
        {
            _context = context;
        }
        public void AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
        }

        public void DeleteCustomer(Customer customer)
        {
            _context.Customers.Remove(customer);
        }

        public Task<Customer[]> GetAllCustomersAsync(bool includeOrders = false)
        {
            //IQueryable<Customer> query = _context.Customers
            //   .Include(c => c.);

            //if (includeOrders)
            //{
            //    query = query
            //      .Include(c => c.Orders.Select(t => new {t.OrderId, t.OrderDate}));
            //}

            //// Order It
            //query = query.OrderByDescending(c => c.EventDate);

            //return await query.ToArrayAsync();

            throw new NotImplementedException();
        }

        public Task<Customer[]> GetAllCustomersByCustomerName(string customerName, bool includeOrders = false)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetCustomerAsync(string customerName, bool includeOrders = false)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
