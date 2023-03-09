using AutoMapper;
using DasherApp.API.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DasherApp.API.Data.Repository
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly AppDbContext context;
        public StatisticsRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<double> GetMileage(DateTime fromDate, DateTime toDate, string location)
        {
            var query = context.DailyDash.Where(x => x.StartTime >= fromDate && x.EndTime <= toDate);

            if(!string.IsNullOrEmpty(location))
            {
                query = query.Where(x => x.Location.ToLower() == location.ToLower());
            }

            var total = await query.SumAsync(x => x.Mileage);
            return total;
        }

        public async Task<double> GetTotalEarned(DateTime fromDate, DateTime toDate, string location)
        {
            var query = context.DailyDash.Where(x => x.StartTime >= fromDate && x.EndTime <= toDate);

            if (!string.IsNullOrEmpty(location))
            {
                query = query.Where(x => x.Location.ToLower() == location.ToLower());
            }

            var total = await query.SumAsync(x => x.Amount);
            return total;
        }
    }
}
