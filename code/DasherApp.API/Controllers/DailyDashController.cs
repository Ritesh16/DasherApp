using DasherApp.API.Data.Repository.Interfaces;
using DasherApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DasherApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailyDashController : ControllerBase
    {
        private readonly IDailyDashRepository dailyDashRepository;

        public DailyDashController(IDailyDashRepository dailyDashRepository)
        {
            this.dailyDashRepository = dailyDashRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await dailyDashRepository.GetAll());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await dailyDashRepository.GetById(id));
        }

        [HttpGet("GetTotalAmount")]
        public async Task<IActionResult> GetTotalAmount()
        {
            return Ok(await dailyDashRepository.TotalEarned());
        }

        [HttpGet("GetTotalMileage")]
        public async Task<IActionResult> GetTotalMileage()
        {
            return Ok(await dailyDashRepository.TotalMileage());
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody]IEnumerable<DailyDashModel> dailyDashList)
        {
            var result = await dailyDashRepository.Save(dailyDashList);
           return Ok(result);
        }

        [HttpPost("UpdateDash")]
        public async Task<IActionResult> Update([FromBody] UpdateDailyDashModel updateDailyDashModel)
        {
            var result = await dailyDashRepository.Update(updateDailyDashModel);
            return Ok(result);
        }
    }
}
