using DasherApp.Models;

namespace DasherApp.Services.Interfaces
{
    public interface IDailyDashService
    {
        Task<bool> SaveDailyDash(DailyDashAddModel dailyDashModel);
        Task<IEnumerable<DailyDashModel>> GetDailyDashList();
    }
}
