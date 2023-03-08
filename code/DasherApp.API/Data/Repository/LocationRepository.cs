using AutoMapper;
using DasherApp.API.Data.Repository.Interfaces;

namespace DasherApp.API.Data.Repository
{
    public class LocationRepository : ILocationRepository
    {
        private readonly AppDbContext context;

        public LocationRepository(AppDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<string> GetLocations()
        {
            return this.context.DailyDash.Select(x => x.Location).Distinct().ToList();
        }
    }
}
