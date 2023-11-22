using DasherApp.Business.Repository.Interface;
using DasherApp.Data;
using DasherApp.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DasherApp.Business.Repository
{
    public class LocationRepository : ILocationRepository
    {
        private readonly AppDbContext _context;
        public LocationRepository(AppDbContext context)
        {
            this._context = context;
        }
        public async Task<IEnumerable<Location>> GetLocations()
        {
            return await _context.Locations.ToListAsync();
        }

        public async Task<bool> LocationExists(string locationName)
        {
            return await _context.Locations.AnyAsync(x => x.Name.ToLower() == locationName.ToLower());
        }

        public async Task Save(string name)
        {
            var location = new Location();
            location.Name = name;
            location.RowUpdateDate= DateTime.Now;
            location.RowCreateDate= DateTime.Now;   
            await _context.Locations.AddAsync(location);
        }
    }
}
