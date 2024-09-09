using AutoMapper;
using AutoMapper.QueryableExtensions;
using DasherApp.Business.Repository.Interface;
using DasherApp.Data;
using DasherApp.Data.Entity;
using DasherApp.Model;
using DasherApp.Model.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DasherApp.Business.Repository
{
    public class LocationRepository : ILocationRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<LocationRepository> _logger;
        private readonly ILogger loggerFactory;

        public LocationRepository(AppDbContext context, IMapper mapper, ILogger<LocationRepository> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
            //this.loggerFactory = loggerFactory.CreateLogger("LocationRepository");
        }
        public async Task<PagedList<LocationModel>> Get()
        {
            _logger.LogInformation("Get all locations. Begin querying database.");
            //loggerFactory.LogInformation("(F)Get all locations. Begin querying database.");

            var locations = _context.Locations.AsQueryable();
            _logger.LogDebug("Creating a paged list.");
            var pagedLocationList = await PagedList<LocationModel>.CreateAsync(locations.ProjectTo<LocationModel>(
            _mapper.ConfigurationProvider).AsNoTracking(), 1, 10);

            return pagedLocationList;
        }

        public async Task<bool> LocationExists(string locationName)
        {
            _logger.LogInformation("Check if {locationName} location exists.", locationName);
            return await _context.Locations.AnyAsync(x => x.Name.ToLower() == locationName.ToLower());
        }

        public async Task Save(string name)
        {
            _logger.LogInformation("Saving {locationName} location.", name);
            var location = new Location();
            location.Name = name;
            location.RowUpdateDate= DateTime.Now;
            location.RowCreateDate= DateTime.Now;   
            await _context.Locations.AddAsync(location);
        }
    }
}
