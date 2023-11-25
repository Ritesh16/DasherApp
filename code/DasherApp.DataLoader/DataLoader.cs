using DasherApp.Business.Extensions;
using DasherApp.Business.Repository;
using DasherApp.Business.Repository.Interface;
using DasherApp.Data;
using DasherApp.Data.Entity;
using DasherApp.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DasherApp.DataLoader
{
    public class DataLoader
    {
        private readonly AppDbContext _context;
        HashSet<string> fileLocations = new HashSet<string>();
        ILocationRepository locationRepository;
        IDailyDashRepository dailyDashRepository;
        IRestaurantRepository restaurantRepository;
        public DataLoader(AppDbContext context)
        {
            this._context = context;
            this.locationRepository = new LocationRepository(_context);
            this.dailyDashRepository = new DailyDashRepository(_context);
            this.restaurantRepository = new RestaurantRepository(_context);
        }
        public async Task LoadDash()
        {
           IDailyDashRepository dailyDashRepository = new DailyDashRepository(_context);
            
            var lines = File.ReadAllLines(Constants.MILEAGE_FILE_PATH);
            Console.WriteLine($"--->{lines.Length} lines found.");
            var dashesList = GetDailyDashList(lines);
            await SaveLocations();

            var storedLocations = await locationRepository.GetLocations();

            var dailyDashList = dashesList.ToDailyDashEntityList(storedLocations.ToList());

            foreach (var dash in dailyDashList)
            {
                await dailyDashRepository.SaveAsync(dash);
            }

            await _context.SaveChangesAsync();
        }

        public async Task LoadRestaurants()
        {
            var url = Constants.DASH_FILE_PATH;
            var data = File.ReadAllLines(url);

            var dashesList = await dailyDashRepository.GetAll();
            
            for (int i = 0; i < data.Length; i++)
            {
                if (i == 0)
                {
                    continue;
                }

                var restaurant = new Restaurant();
                restaurant.RowUpdateDate = DateTime.Now;

                restaurant.RowCreateDate = DateTime.Now;

                restaurant.Name = data[i].Split(',')[3].Replace("\"","");
                restaurant.OrderCreateTime = ConvertToEST(data[i].Split(',')[0].Replace("\"", ""));
                restaurant.OrderPickupTime = ConvertToEST(data[i].Split(',')[1].Replace("\"", ""));
                restaurant.OrderDeliveryTime = ConvertToEST(data[i].Split(',')[2].Replace("\"", ""));
                restaurant.Date = restaurant.OrderCreateTime.Date;
                restaurant.LocationId = dashesList.FirstOrDefault(x => x.Date == restaurant.Date).LocationId;

                restaurantRepository.Save(restaurant);

            }

            await _context.SaveChangesAsync();
        }
        private async Task SaveLocations()
        {
            foreach (var item in fileLocations)
            {
                if(!await locationRepository.LocationExists(item))
                {
                    await locationRepository.Save(item);
                    Console.WriteLine($"Saving {item} location in database.");
                }
            }

            await _context.SaveChangesAsync();
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
                fileLocations.Add(dailyDash.Location);
            }

            return dashesList;
        }

        private DateTime ConvertToEST(string input)
        {
            var date = DateTime.Parse(input, CultureInfo.InvariantCulture);
            var easternZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            var dashDate = TimeZoneInfo.ConvertTimeFromUtc(date, easternZone);
            return dashDate;
        }
    }
}
