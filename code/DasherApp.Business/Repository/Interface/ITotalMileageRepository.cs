using DasherApp.Model.Helper;

namespace DasherApp.Business.Repository.Interface
{
    public interface ITotalMileageRepository
    {
        Task<double> GetTotalMileageAsync(DailyDashFilterParams dailyDashFilterParams);
    }
}
