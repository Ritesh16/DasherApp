using DasherApp.Data.Entity;

namespace DasherApp.Business.Repository.Interface
{
    public interface IDailyDashRepository
    {
        Task SaveAsync(DailyDash dailyDash);
        Task<IEnumerable<DailyDash>> GetAll();
    }
}
