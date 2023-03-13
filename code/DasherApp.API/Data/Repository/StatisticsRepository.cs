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
            //var query = GetDailyDashQuery(fromDate, toDate, location);

            //var output = query.GroupBy(x => x.Date)
            //                  .Select(x => new OutputModel
            //                  {
            //                      Date = x.Key,
            //                      Value = x.Sum(x => x.Amount)
            //                  }).Take(1);

            //return output;

            throw new NotImplementedException();
        }

        public Task<OutputModel> GetHighestMileageDay(DateTime? fromDate, DateTime? toDate, string location)
        {
            throw new NotImplementedException();
        }

        public async Task<double> GetMileage(DateTime? fromDate, DateTime? toDate, string location)
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

            if (fromDate == null || toDate == null)
            {
                query = query.Where(x => x.StartTime >= fromDate && x.EndTime <= toDate);
            }

            if (!string.IsNullOrEmpty(location))
            {
                query = query.Where(x => x.Location.ToLower() == location.ToLower());
            }

            return query;
        }
    }
}
