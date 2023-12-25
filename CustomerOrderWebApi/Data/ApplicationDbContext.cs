using CustomerOrderWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerOrderWebApi.Data
{
    public class ApplicationDbContext : DbContext
    {  
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {        
        }
        // add default values.
        public static void Seed(ApplicationDbContext context)
        {
            if (!context.Customers.Any())
            {
                var customers = new[]
                {
                    new Customer { Id = 1, FirstName = "Michael", LastName = "Jackson"},
                    new Customer { Id = 2, FirstName = "Jason", LastName = "Statham" },
                    new Customer { Id = 3, FirstName = "Dwayne", LastName = "Johnson" }
                };

                var orders = new[]
                {
                    new Order { Id = 1, ProductName = "Iphone 15 Pro Max", Price = 82999, Address = "İstanbul", CustomerId = 1},
                    new Order { Id = 2, ProductName = "Samsung Galaxy S23 Ultra", Price = 55860, Address = "Kocaeli", CustomerId = 2},     
                    new Order { Id = 3, ProductName = "Iphone 12 Pro", Price = 36039, Address = "Düzce", CustomerId = 3}
                };

                context.Customers.AddRange(customers);
                context.Orders.AddRange(orders);
                context.SaveChanges();
            }
        }     
    }
}
