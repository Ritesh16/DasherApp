using DasherApp.Models;

namespace DasherApp.Services.Interfaces
{
    public interface IStatisticsService
    {
        Task<IEnumerable<WeeklyReportModel>> GetWeeklyReports();
        Task<double> GetTotalEarned(FilterModel filterModel);
        Task<double> GetTotalMileage(FilterModel filterModel);
        Task<OutputModel> GetHighestEarningDay(FilterModel filterModel);
        Task<OutputModel> GetHighestMileageDay(FilterModel filterModel);
        Task<double> GetHourlyRate(FilterModel filterModel);
        Task<OutputModel> GetHighestDash(FilterModel filterModel);
        Task<IEnumerable<WeekDayEarningModel>> GetWeekDayEarning(FilterModel filterModel);

    }
}
