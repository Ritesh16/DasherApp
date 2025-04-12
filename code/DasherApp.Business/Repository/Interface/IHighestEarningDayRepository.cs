using DasherApp.Model;
using DasherApp.Model.Helper;

namespace DasherApp.Business.Repository.Interface
{
    public interface IHighestEarningDayRepository
    {
        Task<OutputModel> GetHighestEarningDayAsync(DailyDashFilterParams dailyDashFilterParams);
    }
}
