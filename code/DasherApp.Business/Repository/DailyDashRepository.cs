using AutoMapper;
using DasherApp.Business.Repository.Interface;
using DasherApp.Data;
using DasherApp.Data.Entity;
using DasherApp.Model;
using Microsoft.EntityFrameworkCore;

namespace DasherApp.Business.Repository
{
    public class DailyDashRepository : BaseRepository, IDailyDashRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper mapper;

        public DailyDashRepository(AppDbContext context, IMapper mapper) : base(context)
        {
            _context = context;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<DailyDash>> Get(FilterModel filterModel)
        {
            return await GetDailyDashQuery(filterModel).ToListAsync();
        }

        public async Task<IEnumerable<DailyDashModelV2>> GetAll()
        {
            var dashData = await _context.DailyDashes.Include("Location")
                                .OrderByDescending(x=>x.Id).ToListAsync();

            var dashModelData = mapper.Map<List<DailyDash>, List<DailyDashModelV2>>(dashData);
            foreach (var dash in dashModelData)
            {
                var dashTimeInHour = (dash.EndTime - dash.StartTime).TotalHours;
                dash.HourlyRate = dash.Amount / dashTimeInHour;
            }
            
            return dashModelData;
        }

        public async Task SaveAsync(DailyDash dailyDash)
        {
            await _context.DailyDashes.AddAsync(dailyDash);
        }
    }
}
