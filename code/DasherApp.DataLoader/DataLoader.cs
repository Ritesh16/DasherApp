using DasherApp.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DasherApp.DataLoader
{
    public class DataLoader
    {
        public void LoadDash()
        {
            var lines = File.ReadAllLines(Constants.FILE_PATH);
            Console.WriteLine($"--->{lines.Length} lines found.");
            var dashesList = new List<DailyDash>();
            for (var i = 1; i < lines.Length; i++)
            {
                if (!string.IsNullOrEmpty(lines[i]))
                {
                    var data = lines[i].Split(',');
                    var dailyDash = new DailyDash();
                    dailyDash.Date = Convert.ToDateTime(data[0]);
                    dailyDash.StartTime = ConvertDate(dailyDash.Date, data[1]);
                    dailyDash.EndTime = ConvertDate(dailyDash.Date, data[2]);
                    dailyDash.Amount = Convert.ToDouble(data[3].Trim().Replace("$", ""));
                    dailyDash.Mileage = Convert.ToDouble(data[4].Trim());

                    dashesList.Add(dailyDash);
                }
            }
        }

        private DateTime ConvertDate(DateTime dashDate, string input)
        {
            input = input.Trim();
            return DateTime.ParseExact(dashDate.Date.ToString("MM/dd/yyyy") + " " + input, "MM/dd/yyyy h:mm tt", null, System.Globalization.DateTimeStyles.None);
        }
    }
}
