using DasherApp.API.Data.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using DasherApp.API.Extensions;

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
            DateTime from_Date = fromDate.ParseDate();
            DateTime to_Date = toDate.ParseDate();

            var totalEarned = await statisticsRepository.GetTotalEarned(from_Date, to_Date, location);
            return Ok(totalEarned);
        }

        [HttpGet("GetTotalMileage")]
        public async Task<IActionResult> GetTotalMileage(string fromDate = null, string toDate = null, string location = null)
        {
            DateTime from_Date = fromDate.ParseDate();
            DateTime to_Date = toDate.ParseDate();

            var totalMileage = await statisticsRepository.GetTotalMileage(from_Date, to_Date, location);
            return Ok(totalMileage);
        }

        [HttpGet("GetHighestMileageDay")]
        public async Task<IActionResult> GetHighestMileageDay(string fromDate = null, string toDate = null, string location = null)
        {
            DateTime from_Date = fromDate.ParseDate();
            DateTime to_Date = toDate.ParseDate();

            var totalMileage = await statisticsRepository.GetHighestMileageDay(from_Date, to_Date, location);
            return Ok(totalMileage);
        }

        [HttpGet("GetHighestEarningDay")]
        public async Task<IActionResult> GetHighestEarningDay(string fromDate = null, string toDate = null, string location = null)
        {
            DateTime from_Date = fromDate.ParseDate();
            DateTime to_Date = toDate.ParseDate();

            var highestEarning = await statisticsRepository.GetHighestEarningDay(from_Date, to_Date, location);
            if(highestEarning == null)
            {
                highestEarning = new Models.OutputModel();
            }

            return Ok(highestEarning);
        }

        [HttpGet("GetHourlyRate")]
        public async Task<IActionResult> GetHourlyRate(string fromDate = null, string toDate = null, string location = null)
        {
            DateTime from_Date = fromDate.ParseDate();
            DateTime to_Date = toDate.ParseDate();

            var hourlyRate = await statisticsRepository.GetHourlyRate(from_Date, to_Date, location);
            
            return Ok(hourlyRate);
        }

        [HttpGet("GetHighestDash")]
        public async Task<IActionResult> GetHighestDash(string fromDate = null, string toDate = null, string location = null)
        {
            DateTime from_Date = fromDate.ParseDate();
            DateTime to_Date = toDate.ParseDate();

            var hourlyRate = await statisticsRepository.GetHighestDash(from_Date, to_Date, location);

            return Ok(hourlyRate);
        }

        [HttpGet("GetWeekDayEarning")]
        public async Task<IActionResult> GetWeekDayEarning(string fromDate = null, string toDate = null, string location = null)
        {
            DateTime from_Date = fromDate.ParseDate();
            DateTime to_Date = toDate.ParseDate();

            var weekDayEarnings =  await statisticsRepository.GetWeekDayEarning(from_Date, to_Date, location);
            return Ok(weekDayEarnings);
        }
    }
}
