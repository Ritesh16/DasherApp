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

        public async Task<IEnumerable<DailyDashModel>> GetDailyDashList()
        {
            var response = await _httpClient.GetAsync($"/api/DailyDash");
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var output = JsonConvert.DeserializeObject<IEnumerable<DailyDashModel>>(content);
                return output;
            }
            else
            {
                return new List<DailyDashModel>();
            }
        }

        public async Task<bool> SaveDailyDash(DailyDashAddModel dailyDashModel)
        {
            var dailyDashList = dailyDashModel.ToDailyDash();

            var response = await _httpClient.PostAsJsonAsync($"/api/DailyDash", dailyDashList);
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
