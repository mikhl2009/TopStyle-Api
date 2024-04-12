using Microsoft.EntityFrameworkCore;
using TopStyle_Api.Domain.Entities;

namespace TopStyle_Api.Data
{
    public class TopStyleDbContext : DbContext
    {
        public TopStyleDbContext(DbContextOptions<TopStyleDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

    }
    
}
