using DasherApp.Model.Helper;

namespace DasherApp.Business.Repository.Interface
{
    public interface ITotalEarnedRepository
    {
        Task<double> GetTotalEarnedAsync(DailyDashFilterParams dailyDashFilterParams);
    }
}
