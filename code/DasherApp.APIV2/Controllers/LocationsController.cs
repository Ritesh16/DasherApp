using DasherApp.APIV2.Extensions;
using DasherApp.Business.Repository.Interface;
using DasherApp.Model;
using Microsoft.AspNetCore.Mvc;

namespace DasherApp.APIV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly ILogger<LocationsController> _logger;
        private readonly ILocationRepository _locationRepository;
        public LocationsController(ILogger<LocationsController> logger, ILocationRepository locationRepository)
        {
            _logger = logger;
            _locationRepository = locationRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<LocationModel>> Get()
        {
            _logger.LogInformation("Get all locations.");
            var locations = await _locationRepository.Get();
            _logger.LogDebug("Setting up headers.");
            Response.AddPaginationHeader(locations.CurrentPage, locations.PageSize,
                       locations.TotalCount, locations.TotalPages);

            return locations;
        }
    }
}
