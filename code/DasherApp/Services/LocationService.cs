using DasherApp.Models;
using DasherApp.Services.Interfaces;
using Newtonsoft.Json;

namespace DasherApp.Services
{
    public class LocationService : ILocationService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private string baseServerUrl;
        public LocationService(HttpClient httpClient, IConfiguration configuration)
        {
            this._httpClient = httpClient;
            this._configuration = configuration;
            this.baseServerUrl = _configuration.GetSection("APIUrl").Value;
        }
        public async Task<IEnumerable<string>> GetLocations()
        {
            var response = await _httpClient.GetAsync($"/api/Locations");
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var output = JsonConvert.DeserializeObject<IEnumerable<string>>(content);
                return output;
            }
            else
            {
                return new List<string>();
            }
        }
    }
}
