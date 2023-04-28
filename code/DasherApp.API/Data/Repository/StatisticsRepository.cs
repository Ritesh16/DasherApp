using AutoMapper;
using DasherApp.API.Data.Entity;
using DasherApp.API.Data.Repository.Interfaces;
using DasherApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.Entity.Core.Objects;

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

        public async Task<OutputModel> GetHighestMileageDay(DateTime? fromDate, DateTime? toDate, string location)
        {
            var query = GetDailyDashQuery(fromDate, toDate, location);

            var output = await query.GroupBy(x => x.Date)
                                .Select(g => new OutputModel
                                {
                                    Date = g.Key,
                                    Value = g.Sum(s => s.Mileage)
                                })
                                .OrderByDescending(x => x.Value)
                                .FirstOrDefaultAsync();

            return output;
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
            var query = GetDailyDashQuery(fromDate, toDate, location);
            var amount = await query.SumAsync(x => x.Amount);
            var totalTimeInHour = query.Select(x => (x.EndTime - x.StartTime).TotalSeconds).ToList().Sum();

            if (totalTimeInHour <= 0)
            {
                return 0;
            }

            totalTimeInHour = totalTimeInHour / 3600;

            var hourlyRate = amount / totalTimeInHour;

            return hourlyRate;
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

        public async Task<OutputModel> GetHighestDash(DateTime? fromDate, DateTime? toDate, string location)
        {
            var query = GetDailyDashQuery(fromDate, toDate, location);

            var output = await query.Select(x => new OutputModel
            {
                Date = x.Date,
                Value = x.Amount
            })
             .OrderByDescending(x => x.Value)
             .FirstOrDefaultAsync();

            return output;
        }

        public async Task<IEnumerable<WeekDayEarningModel>> GetWeekDayEarning(DateTime? fromDate, DateTime? toDate, string location)
        {
            var query = GetDailyDashQuery(fromDate, toDate, location);

            var enumerableData = await query.ToListAsync();

            var data = enumerableData
                    .GroupBy(o => o.Date.DayOfWeek)
                    .Select(g => new WeekDayEarningModel  
                                {
                                    DayOfWeek = g.Key, 
                                    Amount = g.Sum(x => x.Amount), 
                                    TotalDashes = g.Count() 
                                })
                    .ToList();


            
            return data;
        }
    }
}
