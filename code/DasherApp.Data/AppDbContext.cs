using DasherApp.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace DasherApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
             : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DailyDash>().ToTable("DailyDash");
            modelBuilder.Entity<Location>().ToTable("Location");
            modelBuilder.Entity<DashDetail>().ToTable("DashDetail");
        }

        public DbSet<DailyDash> DailyDashes { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<DashDetail> DashDetails { get; set; }
    }
}
