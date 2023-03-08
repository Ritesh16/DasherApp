using DasherApp.API.Data.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DasherApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IDailyDashRepository dailyDashRepository;
        public StatisticsController(IDailyDashRepository dailyDashRepository)
        {
            this.dailyDashRepository = dailyDashRepository;
        }

        [HttpGet("GetTotalEarned")]
        public async Task<IActionResult> GetTotalEarned(string fromDate, string toDate)
        {
            return Ok();
        }
    }
}
