using AutoMapper;
using DasherApp.Business.Repository.Interface;
using DasherApp.Data.Entity;
using DasherApp.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DasherApp.APIV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailyDashesController : ControllerBase
    {
        private readonly IDailyDashRepository dailyDashRepository;
        public DailyDashesController(IDailyDashRepository dailyDashRepository)
        {
            this.dailyDashRepository = dailyDashRepository;
        }
        public async Task<IEnumerable<DailyDashModel>> Get()
        {
            var data = await dailyDashRepository.GetAll();
            return data;
        }
    }
}
