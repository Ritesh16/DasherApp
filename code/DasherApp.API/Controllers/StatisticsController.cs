using DasherApp.API.Data.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
            DateTime from_Date = ParseDate(fromDate);
            DateTime to_Date = ParseDate(toDate);

            var totalEarned = await statisticsRepository.GetTotalEarned(from_Date, to_Date, location);
            return Ok(totalEarned);
        }

        [HttpGet("GetTotalMileage")]
        public async Task<IActionResult> GetTotalMileage(string fromDate = null, string toDate = null, string location = null)
        {
            DateTime from_Date = ParseDate(fromDate);
            DateTime to_Date = ParseDate(toDate); 

            var totalMileage = await statisticsRepository.GetTotalMileage(from_Date, to_Date, location);
            return Ok(totalMileage);
        }

        [HttpGet("GetHighestMileageDay")]
        public async Task<IActionResult> GetHighestMileageDay(string fromDate = null, string toDate = null, string location = null)
        {
            DateTime from_Date = ParseDate(fromDate);
            DateTime to_Date = ParseDate(toDate);

            var totalMileage = await statisticsRepository.GetHighestMileageDay(from_Date, to_Date, location);
            return Ok(totalMileage);
        }

        [HttpGet("GetHighestEarningDay")]
        public async Task<IActionResult> GetHighestEarningDay(string fromDate = null, string toDate = null, string location = null)
        {
            DateTime from_Date = ParseDate(fromDate);
            DateTime to_Date = ParseDate(toDate);

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
            DateTime from_Date = ParseDate(fromDate);
            DateTime to_Date = ParseDate(toDate);

            var hourlyRate = await statisticsRepository.GetHourlyRate(from_Date, to_Date, location);
            
            return Ok(hourlyRate);
        }
        private DateTime ParseDate(string dateString)
        {
            var date = DateTime.ParseExact(dateString, "MMddyyyy", CultureInfo.InvariantCulture);
            return date;
        }
    }
}
