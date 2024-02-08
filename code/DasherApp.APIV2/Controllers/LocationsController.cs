using DasherApp.APIV2.Extensions;
using DasherApp.Business.Repository.Interface;
using DasherApp.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DasherApp.APIV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationRepository locationRepository;
        public LocationsController(ILocationRepository locationRepository)
        {
            this.locationRepository = locationRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<LocationModel>> Get()
        {
            var locations = await locationRepository.Get();
            Response.AddPaginationHeader(locations.CurrentPage, locations.PageSize,
                       locations.TotalCount, locations.TotalPages);

            return locations;
        }
    }
}
