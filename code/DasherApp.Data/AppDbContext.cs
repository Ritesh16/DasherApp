using DasherApp.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

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
            //modelBuilder.Entity<DailyDash>().ToTable("DailyDash");
            //modelBuilder.Entity<DashDetail>().ToTable("DashDetail");
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<DailyDash>()
                .HasOne<Location>(d => d.Location)
                .WithMany(u => u.DailyDashes)
                .HasForeignKey(x => x.LocationId);

            modelBuilder.Entity<DashDetail>()
              .HasOne<DailyDash>(d => d.DailyDash)
              .WithMany(u => u.DashDetails)
              .HasForeignKey(x => x.DailyDashId);

            //modelBuilder.Entity<Location>()
            //    .HasMany(d => d.DailyDashes)
            //    .WithOne(u => u.Location)
            //    .HasForeignKey(ur => ur.LocationId)
            //    ;


        }

        public DbSet<DailyDash> DailyDashes { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<DashDetail> DashDetails { get; set; }
    }
}
