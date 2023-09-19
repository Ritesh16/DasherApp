using AutoMapper;
using DasherApp.API.Data.Entity;
using DasherApp.API.Data.Repository.Interfaces;
using DasherApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Globalization;

namespace DasherApp.API.Data.Repository
{
    public class ReportRepository : IReportRepository
    {

        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public ReportRepository(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<DailyDashModel>> GetDailyDashReport(DateTime? fromDate, DateTime? toDate, string location)
        {
            var query = GetDailyDashQuery(fromDate, toDate, location);
            var dailyDashList = await query.ToListAsync();

            return mapper.Map<List<DailyDash>, List<DailyDashModel>>(dailyDashList);
        }

        public async Task<IEnumerable<DailyEarningsModel>> GetDailyEarnings(DateTime? fromDate, DateTime? toDate)
        {
            var query = GetDailyDashQuery(fromDate, toDate, "all");
            var dailyEarnings = query.ToList().GroupBy(x => x.Date)
                .Select(x => new DailyEarningsModel
                {
                    Date = x.Key,
                    Amount = x.Sum(s => s.Amount),
                    Mileage = x.Sum(s => s.Mileage),
                    TotalMinutes = x.Sum(s => (s.EndTime - s.StartTime).TotalMinutes)
                }).OrderByDescending(x => x.Date).ToList();

            return dailyEarnings;
        }

        public async Task<IEnumerable<MonthlyReportModel>> GetMonthlyReport(int year)
        {
            try
            {
                DateTime? fromDate = null;
                DateTime? toDate = null;

                if (year > 0)
                {
                    fromDate = new DateTime(year, 1, 1);
                    toDate = new DateTime(year, 12, 31);
                }

                var query = GetDailyDashQuery(fromDate, toDate, "all");
                var monthlyData = query.GroupBy(x => new { x.Date.Month, x.Date.Year })
                    .Select(x => new MonthlyReportModel
                    {
                        MonthName = DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(x.Key.Month),
                        Month = x.Key.Month,
                        Year = x.Key.Year,
                        Amount = x.Sum(s => s.Amount)
                    }).ToList();

                monthlyData = monthlyData.OrderByDescending(x => x.Year).ThenByDescending(x => x.Month).ToList();

                return monthlyData;

            }
            catch (Exception ex)
            {
                return new List<MonthlyReportModel>();
            }
        }

        public async Task<IEnumerable<WeeklyReportModel>> GetWeeklyReport()
        {

            var weeklyReport = context.WeeklyReportModel.FromSqlRaw(@$"SET DATEFIRST 1;
SELECT   DATEPART(wk, [Date])     WeekId
        , SUM(Amount)           Total
        , DATEADD(dd, -(DATEPART(dw, [Date]) - 1), [Date]) StartDate
        , DATEADD(dd, 7 - (DATEPART(dw, [Date])), [Date]) EndDate
FROM        dailydash
GROUP BY    DATEPART(wk, [Date]), 
DATEADD(dd, -(DATEPART(dw, [Date]) - 1), [Date]), 
DATEADD(dd, 7 - (DATEPART(dw, [Date])), [Date]) 
order by startdate desc
").ToList();

            return weeklyReport;
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
