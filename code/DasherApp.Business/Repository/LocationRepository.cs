using AutoMapper;
using AutoMapper.QueryableExtensions;
using DasherApp.Business.Repository.Interface;
using DasherApp.Data;
using DasherApp.Data.Entity;
using DasherApp.Model;
using DasherApp.Model.Helper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DasherApp.Business.Repository
{
    public class LocationRepository : ILocationRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper mapper;

        public LocationRepository(AppDbContext context, IMapper mapper)
        {
            this._context = context;
            this.mapper = mapper;
        }
        public async Task<PagedList<LocationModel>> Get()
        {
            var locations = _context.Locations.AsQueryable();

            var pagedLocationList = await PagedList<LocationModel>.CreateAsync(locations.ProjectTo<LocationModel>(
            mapper.ConfigurationProvider).AsNoTracking(), 1, 10);

            return pagedLocationList;
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
