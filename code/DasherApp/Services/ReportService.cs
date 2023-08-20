using DasherApp.Models;
using DasherApp.Services.Interfaces;
using Newtonsoft.Json;
using System.Net.Http;

namespace DasherApp.Services
{
    public class ReportService : IReportService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private string baseServerUrl;
        public ReportService(HttpClient httpClient, IConfiguration configuration)
        {
            this._httpClient = httpClient;
            this._configuration = configuration;
            this.baseServerUrl = _configuration.GetSection("APIUrl").Value;
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
