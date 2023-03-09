namespace DasherApp.API.Data.Repository.Interfaces
{
    public interface IStatisticsRepository
    {
        Task<double> GetTotalEarned(DateTime fromDate, DateTime toDate, string location);
        Task<double> GetMileage(DateTime fromDate, DateTime toDate, string location);
    }
}
