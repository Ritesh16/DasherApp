using DasherApp.Models;

namespace DasherApp.Services.Interfaces
{
    public interface IReportService
    {
        Task<IEnumerable<WeeklyReportModel>> GetWeeklyReports();

    }
}
