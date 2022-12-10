using CustomersAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomersAPI.Data
{
    public class CustomersAPIDbContext:DbContext
    {
        public CustomersAPIDbContext(DbContextOptions options) : base(options)
        {


        }

        public DbSet<Customers> Customers { get; set; }
    }
}
