using DasherApp.Models;

namespace DasherApp.Services.Interfaces
{
    public interface IStatisticsService
    {
        Task<IEnumerable<WeeklyReportModel>> GetWeeklyReports();
        Task<double> GetTotalEarned(FilterModel filterModel);
        Task<double> GetTotalMileage(FilterModel filterModel);
    }
}
