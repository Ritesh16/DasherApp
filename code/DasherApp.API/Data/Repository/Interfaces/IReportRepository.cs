using DasherApp.Models;

namespace DasherApp.API.Data.Repository.Interfaces
{
    public interface IReportRepository
    {
        Task<IEnumerable<WeeklyReportModel>> GetWeeklyReport();
    }
}
