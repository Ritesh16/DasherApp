using AutoMapper;
using DasherApp.API.Data.Entity;
using DasherApp.API.Data.Repository.Interfaces;
using DasherApp.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace DasherApp.API.Data.Repository
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly AppDbContext context;
        public StatisticsRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<OutputModel> GetHighestEarningDay(DateTime? fromDate, DateTime? toDate, string location)
        {
            var query = GetDailyDashQuery(fromDate, toDate, location);

            var output = await query.GroupBy(x => x.Date)
                                .Select(g => new OutputModel
                                {
                                    Date = g.Key,
                                    Value = g.Sum(s => s.Amount)
                                })
                                .OrderByDescending(x => x.Value)
                                .FirstOrDefaultAsync();

            return output;
        }

        public Task<OutputModel> GetHighestMileageDay(DateTime? fromDate, DateTime? toDate, string location)
        {
            throw new NotImplementedException();
        }

        public async Task<double> GetTotalMileage(DateTime? fromDate, DateTime? toDate, string location)
        {
            IQueryable<DailyDash> query = GetDailyDashQuery(fromDate, toDate, location);

            var total = await query.SumAsync(x => x.Mileage);
            return total;
        }

        public async Task<double> GetTotalEarned(DateTime? fromDate, DateTime? toDate, string location)
        {
            var query = GetDailyDashQuery(fromDate, toDate, location);

            var total = await query.SumAsync(x => x.Amount);
            return total;
        }

        public async Task<double> GetHourlyRate(DateTime? fromDate, DateTime? toDate, string location)
        {
            try
            {
                IQueryable<DailyDash> query = GetDailyDashQuery(fromDate, toDate, location);
                var amount = await query.SumAsync(x => x.Amount);
                var totalTimeInHour = query.Select(x => (x.EndTime - x.StartTime).TotalSeconds).ToList().Sum();
                var hourlyRate = amount / totalTimeInHour;

                return hourlyRate;
            }
            catch (Exception ex)
            {

            }

            return 0;
        }

        private IQueryable<DailyDash> GetDailyDashQuery(DateTime? fromDate, DateTime? toDate, string location)
        {
            var query = context.DailyDash.AsQueryable();
            location = location.ToLower();

            if (fromDate != null)
            {
                query = query.Where(x => x.StartTime >= fromDate);
            }

            if (toDate != null)
            {
                query = query.Where(x => x.EndTime <= toDate);
            }

            if (!string.IsNullOrEmpty(location) && location != "all")
            {
                query = query.Where(x => x.Location.ToLower() == location);
            }

            return query;
        }
    }
}
