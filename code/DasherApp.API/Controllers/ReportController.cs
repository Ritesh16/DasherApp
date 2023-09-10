using DasherApp.API.Data.Repository.Interfaces;
using DasherApp.API.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DasherApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportRepository reportRepository;

        public ReportController(IReportRepository reportRepository)
        {
            this.reportRepository = reportRepository;
        }

        [HttpGet("WeeklyReport")]
        public async Task<IActionResult> Get()
        {
            return Ok(await reportRepository.GetWeeklyReport());
        }

        [HttpGet("MonthlyReport/{year}")]
        public async Task<IActionResult> GetMonthlyReport(int year)
        {
            return Ok(await reportRepository.GetMonthlyReport(year));
        }

        [HttpGet("DailyReport")]
        public async Task<IActionResult> GetDailyReport(string fromDate = null, string toDate = null, string location = null)
        {
            DateTime from_Date = fromDate.ParseDate();
            DateTime to_Date = toDate.ParseDate();

            return Ok(await reportRepository.GetDailyDashReport(from_Date, to_Date, location));
        }

    }
}
