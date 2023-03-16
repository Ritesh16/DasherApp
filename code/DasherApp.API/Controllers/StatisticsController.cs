using DasherApp.API.Data.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace DasherApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsRepository statisticsRepository;
        public StatisticsController(IStatisticsRepository statisticsRepository)
        {
            this.statisticsRepository = statisticsRepository;
        }

        [HttpGet("GetTotalEarned")]
        public async Task<IActionResult> GetTotalEarned(string fromDate = null, string toDate = null, string location = null)
        {
            DateTime from_Date = DateTime.ParseExact(fromDate, "MMddyyyy", CultureInfo.InvariantCulture);
            DateTime to_Date = DateTime.ParseExact(toDate, "MMddyyyy", CultureInfo.InvariantCulture);

            var totalEarned = await statisticsRepository.GetTotalEarned(from_Date, to_Date, location);
            return Ok(totalEarned);
        }

    }
}
