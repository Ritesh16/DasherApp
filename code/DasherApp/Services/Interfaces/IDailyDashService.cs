using DasherApp.Models;

namespace DasherApp.Services.Interfaces
{
    public interface IDailyDashService
    {
        Task<bool> SaveDailyDash(DailyDashAddModel dailyDashModel);
        Task<double> GetTotalEarned();
        Task<double> GetTotalMileage();
        Task<IEnumerable<DailyDashModel>> GetDailyDashList();
    }
}
