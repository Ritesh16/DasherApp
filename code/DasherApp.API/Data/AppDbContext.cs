using DasherApp.API.Data.Entity;
using DasherApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DasherApp.API.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options)
             : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WeeklyReportModel>().HasNoKey();
        }


        public DbSet<DailyDash> DailyDash { get; set; }
        public DbSet<WeeklyReportModel> WeeklyReportModel { get; set; }
    }
}
