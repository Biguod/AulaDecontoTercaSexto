using Microsoft.EntityFrameworkCore;
using UserProductMinimal.Models;

namespace UserProductMinimal.Contexts
{
    public class DataBaseContext : DbContext
    {
        
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) { }
        public DataBaseContext() { }

        public DbSet<Product> Product { get; set; }
        //public DbSet<User> User { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        

    }
}
