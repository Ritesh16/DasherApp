using DasherApp.Business.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DasherApp.Business.Repository.Interface;
using DasherApp.APIV2.Extensions;
using DasherApp.Model.Helper;
using DasherApp.Model;

namespace DasherApp.APIV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EarningsController : ControllerBase
    {
        private readonly ITotalEarnedRepository totalEarnedRepository;
        public EarningsController(ITotalEarnedRepository totalEarnedRepository)
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
