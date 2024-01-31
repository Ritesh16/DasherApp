using AutoMapper;
using DasherApp.APIV2.Extensions;
using DasherApp.Business.Repository.Interface;
using DasherApp.Data.Entity;
using DasherApp.Model;
using DasherApp.Model.Helper;
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

        [HttpGet("All")]
        public async Task<IEnumerable<DailyDashModelV2>> Get()
        {
            var data = await dailyDashRepository.GetAll();
            return data;
        }

        [HttpGet()]
        public async Task<IEnumerable<DailyDashModelV2>> Get([FromQuery] DailyDashFilterParams dailyDashFilterParams)
        {
            var dailyDashes = await dailyDashRepository.Get(dailyDashFilterParams);
            Response.AddPaginationHeader(dailyDashes.CurrentPage, dailyDashes.PageSize,
                       dailyDashes.TotalCount, dailyDashes.TotalPages);

            return dailyDashes;
        }
    }
}
