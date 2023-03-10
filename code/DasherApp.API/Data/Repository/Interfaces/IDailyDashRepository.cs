using DasherApp.Models;

namespace DasherApp.API.Data.Repository.Interfaces
{
    public interface IDailyDashRepository
    {
        Task<IEnumerable<DailyDashModel>> GetAll();
        Task<bool> Save(IEnumerable<DailyDashModel> dailyDashList);
        Task<double> TotalEarned();
        Task<double> TotalMileage();
    }
}
