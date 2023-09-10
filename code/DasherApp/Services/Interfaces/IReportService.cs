using DasherApp.Models;

namespace DasherApp.Services.Interfaces
{
    public interface IReportService
    {
        Task<IEnumerable<WeeklyReportModel>> GetWeeklyReports();
        Task<IEnumerable<MonthlyReportModel>> GetMonthlyReports(int year);
        Task<IEnumerable<DailyDashModel>> GetDailyDashReport(FilterModel filterModel);
        Task<IEnumerable<int>> GetYears();
    }
}
