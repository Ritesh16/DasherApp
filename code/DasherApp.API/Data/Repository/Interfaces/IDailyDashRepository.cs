using DasherApp.Models;

namespace DasherApp.API.Data.Repository.Interfaces
{
    public interface IDailyDashRepository
    {
        Task<IEnumerable<DailyDashModel>> GetAll();
        Task<UpdateDailyDashModel> GetById(int id);
        Task<bool> Save(IEnumerable<DailyDashModel> dailyDashList);
        Task<double> TotalEarned();
        Task<double> TotalMileage();
        Task<bool> Update(UpdateDailyDashModel updateDailyDashModel);
    }
}
