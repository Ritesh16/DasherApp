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
        private readonly ILogger<TotalEarningsController> _logger;

        public TotalEarningsController(ITotalEarnedRepository totalEarnedRepository, ILogger<TotalEarningsController> logger)
        {
            this.totalEarnedRepository = totalEarnedRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<double> Get([FromQuery] DailyDashFilterParams dailyDashFilterParams)
        {
            _logger.LogInformation("Get TotalEarned from {dailyDashFilterParams.FromDate} to {dailyDashFilterParams.ToDate}", dailyDashFilterParams.FromDate, dailyDashFilterParams.ToDate);
            var totalEarned = await totalEarnedRepository.GetTotalEarnedAsync(dailyDashFilterParams);
            return totalEarned;
        }
    }
}
