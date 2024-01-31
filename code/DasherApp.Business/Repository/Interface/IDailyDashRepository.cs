using DasherApp.Data.Entity;
using DasherApp.Model;
using DasherApp.Model.Helper;

namespace DasherApp.Business.Repository.Interface
{
    public interface IDailyDashRepository
    {
        Task SaveAsync(DailyDash dailyDash);
        Task<IEnumerable<DailyDashModelV2>> GetAll();
        Task<PagedList<DailyDashModelV2>> Get(DailyDashFilterParams dailyDashFilterParams);
    }
}
