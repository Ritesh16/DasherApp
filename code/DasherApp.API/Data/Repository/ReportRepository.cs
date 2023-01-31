using DasherApp.API.Data.Repository.Interfaces;
using DasherApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace DasherApp.API.Data.Repository
{
    public class ReportRepository : IReportRepository
    {

        private readonly AppDbContext context;

        public ReportRepository(AppDbContext context)
        {
            this.context = context;
        }

        public DataTable GetAverageTemperatures()
        {
            using (var command = context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = @$"SET DATEFIRST 1;
SELECT   DATEPART(wk, [Date])     WeekId
        , SUM(Amount)           Total
        , DATEADD(dd, -(DATEPART(dw, [Date]) - 1), [Date]) StartDate
        , DATEADD(dd, 7 - (DATEPART(dw, [Date])), [Date]) EndDate
FROM        dailydash
GROUP BY    DATEPART(wk, [Date]), 
DATEADD(dd, -(DATEPART(dw, [Date]) - 1), [Date]), 
DATEADD(dd, 7 - (DATEPART(dw, [Date])), [Date]) ";


                using (var reader = command.ExecuteReader())
                {
                    var table = new DataTable();
                    table.Load(reader);

                    return table;
                }
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
    }
}
