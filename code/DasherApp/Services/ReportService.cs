using DasherApp.Extensions;
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

        public async Task<IEnumerable<DailyDashModel>> GetDailyDashReport(FilterModel filterModel)
        {
            var url = $"{this.baseServerUrl}/api/Report/DailyReport";
            url = url + "?fromDate=" + filterModel.FromDate.ToDateTimeString() + "&toDate=" + filterModel.ToDate.ToDateTimeString() + "&location=" + filterModel.Location;
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var output = JsonConvert.DeserializeObject<IEnumerable<DailyDashModel>>(content);
                return output;
            }

            return new List<DailyDashModel>();
        }

        public async Task<IEnumerable<MonthlyReportModel>> GetMonthlyReports(int year)
        {
            var response = await _httpClient.GetAsync($"{this.baseServerUrl}/api/Report/MonthlyReport/{year}");
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var output = JsonConvert.DeserializeObject<IEnumerable<MonthlyReportModel>>(content);
                return output;
            }

            return new List<MonthlyReportModel>();
        }

        public async Task<IEnumerable<WeeklyReportModel>> GetWeeklyReports()
        {
            var response = await _httpClient.GetAsync($"{this.baseServerUrl}/api/Report/WeeklyReport");
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var output = JsonConvert.DeserializeObject<IEnumerable<WeeklyReportModel>>(content);
                return output;
            }

            return new List<WeeklyReportModel>();
        }

        public async Task<IEnumerable<int>> GetYears()
        {
            var years = new List<int>();
            int startYear = 2022;
            int currentYear = DateTime.Today.Year;
            while(startYear <= currentYear)
            {
                years.Add(startYear);
                startYear++;
            }

            return await Task.FromResult<IEnumerable<int>>(years);     
        }
    }
}
