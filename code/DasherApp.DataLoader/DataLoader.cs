using DasherApp.Data;
using DasherApp.Data.Entity;
using DasherApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DasherApp.DataLoader
{
    public class DataLoader
    {
        private readonly AppDbContext _context;
        HashSet<string> locations = new HashSet<string>();
        public DataLoader(AppDbContext context)
        {
            this._context = context;
        }
        public void LoadDash()
        {
            var lines = File.ReadAllLines(Constants.FILE_PATH);
            Console.WriteLine($"--->{lines.Length} lines found.");
            var dashesList = GetDailyDashList(lines);


        }

        private DateTime ConvertDate(DateTime dashDate, string input)
        {
            input = input.Trim();
            return DateTime.ParseExact(dashDate.Date.ToString("MM/dd/yyyy") + " " + input, "MM/dd/yyyy h:mm tt", null, System.Globalization.DateTimeStyles.None);
        }
        private List<DailyDashModel> GetDailyDashList(string[] lines)
        {
            var dashesList = new List<DailyDashModel>();
            for (var i = 1; i < lines.Length; i++)
            {
                if (string.IsNullOrEmpty(lines[i]))
                {
                    continue;
                }

                var data = lines[i].Split(',');
                var dailyDash = new DailyDashModel();
                dailyDash.Date = Convert.ToDateTime(data[0]);
                dailyDash.StartTime = ConvertDate(dailyDash.Date, data[1]);
                dailyDash.EndTime = ConvertDate(dailyDash.Date, data[2]);
                dailyDash.Amount = Convert.ToDouble(data[3].Trim().Replace("$", ""));
                dailyDash.Mileage = Convert.ToDouble(data[4].Trim());
                dailyDash.Location = data[5].Trim();
                dashesList.Add(dailyDash);
                locations.Add(dailyDash.Location);
            }

            return dashesList;
        }
    }
}
