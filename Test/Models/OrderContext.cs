using System.Data.Entity;

namespace Test.Models
{
    public class OrderContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
    }
}