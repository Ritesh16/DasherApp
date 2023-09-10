using DasherApp.Models;

namespace DasherApp.API.Data.Repository.Interfaces
{
    public interface IReportRepository
    {
        Task<IEnumerable<WeeklyReportModel>> GetWeeklyReport();
        Task<IEnumerable<MonthlyReportModel>> GetMonthlyReport(int year);
        Task<IEnumerable<DailyDashModel>> GetDailyDashReport(DateTime? fromDate, DateTime? toDate, string location);
    }
}
