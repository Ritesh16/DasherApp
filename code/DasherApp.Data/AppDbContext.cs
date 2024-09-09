using DasherApp.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace DasherApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
            
        }
        public AppDbContext(DbContextOptions<AppDbContext> options)
             : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
  => options.UseSqlServer("Server=RITESH-PC\\SQLEXPRESS;Database=DoorDashV2;Trusted_Connection=True;TrustServerCertificate=True");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DailyDash>()
                .HasOne<Location>(d => d.Location)
                .WithMany(u => u.DailyDashes)
                .HasForeignKey(x => x.LocationId);

            modelBuilder.Entity<DashDetail>()
              .HasOne<DailyDash>(d => d.DailyDash)
              .WithMany(u => u.DashDetails)
              .HasForeignKey(x => x.DailyDashId);
        }
        public DbSet<DailyDash> DailyDashes { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<DashDetail> DashDetails { get; set; }
    }
}
