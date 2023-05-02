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
        public DbSet<LineItem> LineItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            this.ApplyNewMigrations();
            modelBuilder.Entity<LineItem>()
                .HasOne<Order>()
                .WithMany(l => l.Lines)
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
                Console.WriteLine("Ошибка при миграции",ex);
            }
        }

    }
}