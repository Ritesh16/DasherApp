using DasherApp.Models;

namespace DasherApp.API.Data.Repository.Interfaces
{
    public interface IStatisticsRepository
    {
        Task<double> GetTotalEarned(DateTime? fromDate, DateTime? toDate, string location);
        Task<double> GetTotalMileage(DateTime? fromDate, DateTime? toDate, string location);
        Task<OutputModel> GetHighestEarningDay(DateTime? fromDate, DateTime? toDate, string location);
        Task<OutputModel> GetHighestMileageDay(DateTime? fromDate, DateTime? toDate, string location);
        Task<double> GetHourlyRate(DateTime? fromDate, DateTime? toDate, string location);
        Task<OutputModel> GetHighestDash(DateTime? fromDate, DateTime? toDate, string location);

    }
}
