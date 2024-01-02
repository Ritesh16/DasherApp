using DasherApp.Data.Entity;
using DasherApp.Model;

namespace DasherApp.Business.Repository.Interface
{
    public interface IDailyDashRepository
    {
        Task SaveAsync(DailyDash dailyDash);
        Task<IEnumerable<DailyDashModel>> GetAll();
        Task<IEnumerable<DailyDash>> Get(FilterModel filterModel);
    }
}
