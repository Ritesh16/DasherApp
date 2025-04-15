using DasherApp.APIV2.Extensions;
using DasherApp.Business.Repository.Interface;
using DasherApp.Model;
using DasherApp.Model.Helper;
using Microsoft.AspNetCore.Mvc;

namespace DasherApp.APIV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TotalMileageController : ControllerBase
    {
        private readonly ITotalMileageRepository totalMileageRepository;
        private readonly ILogger<TotalEarningsController> logger;

        public TotalMileageController(ITotalMileageRepository totalMileageRepository, ILogger<TotalEarningsController> appLogger)
        {
            this.totalMileageRepository = totalMileageRepository;
            this.logger = appLogger;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] DailyDashFilterParams dailyDashFilterParams)
        {
            logger.LogInformation("Get TotalMileage from {dailyDashFilterParams.FromDate} to {dailyDashFilterParams.ToDate}", dailyDashFilterParams.FromDate, dailyDashFilterParams.ToDate);
            var totalMileage = await totalMileageRepository.GetTotalMileageAsync(dailyDashFilterParams);

            if (totalMileage == 0)
            {
                logger.LogWarning("Unable to find Total Mileage for the date range.");
                return NotFound("Total Mileage not found!".Failure<ApiResponse<OutputModel>>());
            }

            return Ok(totalMileage.Success<double>());
        }
    }
}
