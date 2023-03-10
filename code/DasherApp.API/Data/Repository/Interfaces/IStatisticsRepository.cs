using DasherApp.Models;

namespace DasherApp.API.Data.Repository.Interfaces
{
    public interface IStatisticsRepository
    {
        Task<double> GetTotalEarned(DateTime? fromDate, DateTime? toDate, string location);
        Task<double> GetMileage(DateTime? fromDate, DateTime? toDate, string location);
        Task<OutputModel> GetHighestEarningDay(DateTime? fromDate, DateTime? toDate, string location);
        Task<OutputModel> GetHighestMileageDay(DateTime? fromDate, DateTime? toDate, string location);
    }
}
