using DasherApp.API.Data.Repository.Interfaces;
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

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(reportRepository.GetWeeklyReport());
        }

    }
}
