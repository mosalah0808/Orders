using Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFramework
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public DbSet<Order> Orders { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            this.ApplyNewMigrations();
            modelBuilder.Entity<Order>()
                .HasMany(o => o.Lines)
                .WithOne(l => l.Order)
                .HasForeignKey(l => l.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        private void ApplyNewMigrations()
        {
            try
            {
                if (this.Database.GetPendingMigrations().Count() != 0)
                {
                    this.Database.Migrate();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception while migration.",ex);
            }
        }

    }
}