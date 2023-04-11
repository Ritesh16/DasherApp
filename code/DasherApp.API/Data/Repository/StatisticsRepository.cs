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

        public Task<OutputModel> GetHighestEarningDay(DateTime? fromDate, DateTime? toDate, string location)
        {
            var query = GetDailyDashQuery(fromDate, toDate, location);

            var output = query.GroupBy(x => x.Date)
                              .Select(grp => grp.ToList()).Take(1);


            throw new NotImplementedException();
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
