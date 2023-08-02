using AutoMapper;
using DasherApp.API.Data.Entity;
using DasherApp.API.Data.Repository.Interfaces;
using DasherApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

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

            //            var weeklyReport = context.Database
            //                                .SqlQuery<WeeklyReportModel>(@$"SET DATEFIRST 1;
            //SELECT   DATEPART(wk, [Date])     WeekId
            //        , SUM(Amount)           Total
            //        , DATEADD(dd, -(DATEPART(dw, [Date]) - 1), [Date]) StartDate
            //        , DATEADD(dd, 7 - (DATEPART(dw, [Date])), [Date]) EndDate
            //FROM        dailydash
            //GROUP BY    DATEPART(wk, [Date]), DATEADD(dd, -(DATEPART(dw, [Date]) - 1), [Date]), DATEADD(dd, 7 - (DATEPART(dw, [Date])), [Date]) ")

            //                                .Select(x => new WeeklyReportModel
            //                                {
            //                                    EndDate = x.EndDate,
            //                                    StartDate = x.StartDate,
            //                                    Total = x.Total,
            //                                    WeekId = x.WeekId
            //                                })
            //                                .ToList();


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
