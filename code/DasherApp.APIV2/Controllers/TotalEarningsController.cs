using DasherApp.Business.Repository.Interface;
using DasherApp.Model.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DasherApp.APIV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TotalEarningsController : ControllerBase
    {
        private readonly ITotalEarnedRepository totalEarnedRepository;
        public TotalEarningsController(ITotalEarnedRepository totalEarnedRepository)
        {
            this.totalEarnedRepository = totalEarnedRepository;
        }

        [HttpGet]
        public async Task<double> Get([FromQuery] DailyDashFilterParams dailyDashFilterParams)
        {
            var totalEarned = await totalEarnedRepository.GetTotalEarnedAsync(dailyDashFilterParams);
            return totalEarned;
        }
    }
}
