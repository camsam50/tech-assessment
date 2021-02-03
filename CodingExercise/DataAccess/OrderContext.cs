using CodingExercise.Models;
using Microsoft.EntityFrameworkCore;

namespace CodingExercise.DataAccess
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options)
            : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
    }
}
