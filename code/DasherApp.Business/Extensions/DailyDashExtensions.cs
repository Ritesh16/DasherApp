using DasherApp.Data.Entity;
using DasherApp.Model;

namespace DasherApp.Business.Extensions
{
    public static class DailyDashExtensions
    {
        public static List<DailyDash> ToDailyDashEntityList(this List<DailyDashModel> dailyDashModelList, List<Location> locations)
        {
            var result = new List<DailyDash>();

            foreach (var dailyDashModel in dailyDashModelList)
            {
                var dailyDash = new DailyDash();
                dailyDash.Amount = dailyDashModel.Amount;
                dailyDash.RowUpdateDate = DateTime.Now;
                dailyDash.RowCreateDate = DateTime.Now;
                dailyDash.Date = dailyDashModel.Date;
                dailyDash.LocationId = locations.FirstOrDefault(x => x.Name.ToLower() == dailyDashModel.Location.ToLower()).Id;
                dailyDash.Mileage = dailyDashModel.Mileage;
                dailyDash.StartTime = dailyDashModel.StartTime;
                dailyDash.EndTime = dailyDashModel.EndTime; 
                result.Add(dailyDash);
            }

            return result;
        }
    }
}
