using DasherApp.Models;
using DasherApp.Services.Interfaces;
using Newtonsoft.Json;
using System.Text;
using DasherApp.Extensions;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace DasherApp.Services
{
    public class DailyDashService : IDailyDashService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private string baseServerUrl;
        public DailyDashService(HttpClient httpClient, IConfiguration configuration)
        {
            this._httpClient = httpClient;
            this._configuration = configuration;
            this.baseServerUrl = _configuration.GetSection("APIUrl").Value;
        }

        public async Task<UpdateDailyDashModel> GetDailyDashById(int id)
        {
            var url = $"{this.baseServerUrl}/api/DailyDash/{id}";
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var output = JsonConvert.DeserializeObject<UpdateDailyDashModel>(content);
                return output;
            }

            return new UpdateDailyDashModel();
        }

        public async Task<IEnumerable<DailyDashModel>> GetDailyDashList()
        {
            var response = await _httpClient.GetAsync($"{this.baseServerUrl}/api/DailyDash");
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var output = JsonConvert.DeserializeObject<IEnumerable<DailyDashModel>>(content);
                foreach (var item in output)
                {
                    var hours = (item.EndTime - item.StartTime).TotalHours;
                    item.HourlyRate = Math.Round(item.Amount / hours, 2);
                }

                return output;
            }
            else
            {
                return new List<DailyDashModel>();
            }
        }

        public async Task<double> GetTotalEarned()
        {
            var response = await _httpClient.GetAsync($"{this.baseServerUrl}/api/DailyDash/GetTotalAmount");
            var content = await response.Content.ReadAsStringAsync();
            double output = 0;
            if (response.IsSuccessStatusCode)
            {
                output = JsonConvert.DeserializeObject<double>(content);
            }

            return output;
        }

        public async Task<double> GetTotalMileage()
        {
            var response = await _httpClient.GetAsync($"{this.baseServerUrl}/api/DailyDash/GetTotalMileage");
            var content = await response.Content.ReadAsStringAsync();
            double output = 0;
            if (response.IsSuccessStatusCode)
            {
                output = JsonConvert.DeserializeObject<double>(content);
            }

            return output;
        }

        public async Task<bool> SaveDailyDash(DailyDashAddModel dailyDashModel)
        {
            var dailyDashList = dailyDashModel.ToDailyDash();

            var response = await _httpClient.PostAsJsonAsync($"{this.baseServerUrl}/api/DailyDash", dailyDashList);
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var output = JsonConvert.DeserializeObject<bool>(content);
                return output;
            }
            else
            {
                return false;
            }
        }
        public async Task<bool> UpdateDailyDash(UpdateDailyDashModel updateDailyDashModel)
        {
            var response = await _httpClient.PostAsJsonAsync($"{this.baseServerUrl}/api/DailyDash/UpdateDash", updateDailyDashModel);
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var output = JsonConvert.DeserializeObject<bool>(content);
                return output;
            }
            else
            {
                return false;
            }
        }
    }
}
