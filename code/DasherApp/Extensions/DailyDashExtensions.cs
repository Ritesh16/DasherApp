using DasherApp.Models;

namespace DasherApp.Extensions
{
    public static class DailyDashExtensions
    {
        public static IEnumerable<DailyDashModel> ToDailyDash(this DailyDashAddModel model)
        {
            var dailyDashList = new List<DailyDashModel>();

            foreach (var item in model.DashTimes)
            {
                var dailyDash = new DailyDashModel();
                dailyDash.IsActive = true;
                dailyDash.Location = model.Location;
                dailyDash.StartTime = model.DateTime.Date.Add(item.StartTime);
                dailyDash.EndTime = model.DateTime.Date.Add(item.EndTime);
                dailyDash.Mileage = item.Mileage;
                dailyDash.Amount = item.Amount;
                dailyDash.Date = model.DateTime;
                dailyDash.Restaurant = "x";
                dailyDashList.Add(dailyDash);
            }

            return dailyDashList;
        }
    }
}
