using Microsoft.EntityFrameworkCore;

namespace Temp.DataAccess.Data
{    
    /// <summary>
    /// DbContext
    /// </summary>
    public class DataContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        
        public DbSet<Product> Products { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<User> Carts { get; set; }

        public DbSet<User> CartDetails { get; set; }

        public DbSet<User> Comments { get; set; }

        public DbSet<User> Images { get; set; }

        public DbSet<User> Nsxs { get; set; }

        public DbSet<User> Sales { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) {}
    }
}