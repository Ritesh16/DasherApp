using DasherApp.Business.Repository.Interface;
using DasherApp.Model.Helper;
using Microsoft.AspNetCore.Mvc;

namespace DasherApp.APIV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HighestEarningDaysController : ControllerBase
    {
        private readonly IHighestEarningDayRepository highestEarningDayRepository;
        private readonly ILogger<TotalEarningsController> logger;

        public HighestEarningDaysController(IHighestEarningDayRepository highestEarningDayRepository, ILogger<TotalEarningsController> logger)
        {
            this.highestEarningDayRepository = highestEarningDayRepository;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] DailyDashFilterParams dailyDashFilterParams)
        {
            logger.LogInformation("Get Highest Earning Day from {dailyDashFilterParams.FromDate} to {dailyDashFilterParams.ToDate}", dailyDashFilterParams.FromDate, dailyDashFilterParams.ToDate);
            var highestEarningDay = await highestEarningDayRepository.GetHighestEarningDayAsync(dailyDashFilterParams);
            return Ok(highestEarningDay);
        }

    }
}
