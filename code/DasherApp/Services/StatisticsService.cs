using DasherApp.Models;
using DasherApp.Services.Interfaces;
using Newtonsoft.Json;
using DasherApp.Extensions;

namespace DasherApp.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private string baseServerUrl;
        public StatisticsService(HttpClient httpClient, IConfiguration configuration)
        {
            this._httpClient = httpClient;
            this._configuration = configuration;
            this.baseServerUrl = _configuration.GetSection("APIUrl").Value;
        }

        public async Task<double> GetTotalEarned(FilterModel filterModel)
        {
            var url = $"/api/Statistics/GetTotalEarned";
            if (!filterModel.SearchWithoutDates)
            {
                url = url + "?fromDate=" + filterModel.FromDate.ToDateTimeString() + "&toDate=" + filterModel.ToDate.ToDateTimeString() + "&location=" + filterModel.Location;
            }
            else
            {
                url = url + "?fromDate=" +  "&toDate="  + "&location=" + filterModel.Location;
            }

            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            double output = 0;
            
            if (response.IsSuccessStatusCode)
            {
                output = JsonConvert.DeserializeObject<double>(content);
            }

            return output;
        }

        public async Task<IEnumerable<WeeklyReportModel>> GetWeeklyReports()
        {
            var response = await _httpClient.GetAsync($"/api/Report/WeeklyReport");
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var output = JsonConvert.DeserializeObject<IEnumerable<WeeklyReportModel>>(content);
                return output;
            }
            else
            {
                return new List<WeeklyReportModel>();
            }
        }
    }
}
