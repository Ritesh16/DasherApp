using DasherApp.API.Data.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace DasherApp.API.Controllers
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
        public IActionResult Get()
        {
            var date = DateTime.ParseExact("03082023", "MMddyyyy", CultureInfo.InvariantCulture);
            var locations = locationRepository.GetLocations();
            return Ok(locations);
        }
    }
}
