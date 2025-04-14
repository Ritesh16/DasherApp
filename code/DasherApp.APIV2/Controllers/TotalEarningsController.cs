using DasherApp.APIV2.Extensions;
using DasherApp.Business.Repository.Interface;
using DasherApp.Model;
using DasherApp.Model.Helper;
using Microsoft.AspNetCore.Mvc;

namespace DasherApp.APIV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TotalEarningsController : ControllerBase
    {
        private readonly ITotalEarnedRepository totalEarnedRepository;
        private readonly ILogger<TotalEarningsController> logger;

        public TotalEarningsController(ITotalEarnedRepository totalEarnedRepository, ILogger<TotalEarningsController> appLogger)
        {
            this.totalEarnedRepository = totalEarnedRepository;
            logger = appLogger;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] DailyDashFilterParams dailyDashFilterParams)
        {
            logger.LogInformation("Get TotalEarned from {dailyDashFilterParams.FromDate} to {dailyDashFilterParams.ToDate}", dailyDashFilterParams.FromDate, dailyDashFilterParams.ToDate);
            var totalEarned = await totalEarnedRepository.GetTotalEarnedAsync(dailyDashFilterParams);

            if (totalEarned == 0)
            {
                logger.LogWarning("Unable to find Total Earned for the date range.");
                return NotFound("Total earned not found!".Failure<ApiResponse<OutputModel>>());
            }

            return Ok(totalEarned.Success<double>());
        }
    }
}
