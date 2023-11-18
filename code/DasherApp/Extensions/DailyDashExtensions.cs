using DasherApp.Models;
using System.Text;

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

        public static string ToCsvData(this IEnumerable<DailyDashModel> dailyDashList)
        {
            var csv = new StringBuilder();
            csv.AppendLine($"Date, StartTime, EndTime, Amount, Mileage, Location");

            foreach (var dailyDash in dailyDashList)
            {
                var ss = dailyDash.StartTime.ToString("hh:mm tt");
                var newLine = $"{dailyDash.Date.ToString("MMM-dd")}, {dailyDash.StartTime.ToString("hh:mm tt")}, {dailyDash.EndTime.ToString("hh:mm tt")}, {dailyDash.Amount.ToString("C2")}, {dailyDash.Mileage}, {dailyDash.Location}";
                csv.AppendLine(newLine);
            }

            csv.AppendLine("");
            csv.AppendLine($"Total, ,, ${dailyDashList.Sum(x => x.Amount)}, {dailyDashList.Sum(x => x.Mileage)} ");

            return csv.ToString();
        }
    }
}
