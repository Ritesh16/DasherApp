using DasherApp.Models;

namespace DasherApp.Services.Interfaces
{
    public interface IDailyDashService
    {
        Task<bool> SaveDailyDash(DailyDashAddModel dailyDashModel);
        Task<bool> UpdateDailyDash(UpdateDailyDashModel updateDailyDashModel);
        Task<double> GetTotalEarned();
        Task<double> GetTotalMileage();
        Task<IEnumerable<DailyDashModel>> GetDailyDashList();
        Task<UpdateDailyDashModel> GetDailyDashById(int id);
    }
}
