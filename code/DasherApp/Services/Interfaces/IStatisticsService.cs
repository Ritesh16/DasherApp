using DasherApp.Models;

namespace DasherApp.Services.Interfaces
{
    public interface IStatisticsService
    {
        Task<IEnumerable<WeeklyReportModel>> GetWeeklyReports();
    }
}
