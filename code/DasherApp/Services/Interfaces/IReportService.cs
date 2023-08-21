using DasherApp.Models;

namespace DasherApp.Services.Interfaces
{
    public interface IReportService
    {
        Task<IEnumerable<WeeklyReportModel>> GetWeeklyReports();
        Task<IEnumerable<DailyDashModel>> GetDailyDashReport(FilterModel filterModel);

    }
}
