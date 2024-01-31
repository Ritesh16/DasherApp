using AutoMapper;
using AutoMapper.QueryableExtensions;
using DasherApp.Business.Repository.Interface;
using DasherApp.Data;
using DasherApp.Data.Entity;
using DasherApp.Model;
using DasherApp.Model.Helper;
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

        public async Task<PagedList<DailyDashModelV2>> Get(DailyDashFilterParams dailyDashFilterParams)
        {
            var dashData = _context.DailyDashes.OrderByDescending(x => x.Date).AsQueryable();

            if (dailyDashFilterParams.FromDate != null)
            {
                dashData = dashData.Where(x => x.StartTime >= dailyDashFilterParams.FromDate);
            }

            if (dailyDashFilterParams.ToDate != null)
            {
                dashData = dashData.Where(x => x.EndTime <= dailyDashFilterParams.ToDate);
            }

            dashData = dashData.Include(x => x.Location).Include(x => x.DashDetails);

            if (!string.IsNullOrEmpty(dailyDashFilterParams.Location) && dailyDashFilterParams.Location.ToLower() != "all")
            {
                dashData = dashData.Where(x => x.Location.Name.ToLower() == dailyDashFilterParams.Location.ToLower());
            }

            return await PagedList<DailyDashModelV2>.CreateAsync(dashData.ProjectTo<DailyDashModelV2>(
                    mapper.ConfigurationProvider).AsNoTracking(), dailyDashFilterParams.PageNumber, dailyDashFilterParams.PageSize);
        }

        public async Task<IEnumerable<DailyDashModelV2>> GetAll()
        {
            var dashData = await _context.DailyDashes.Include(x => x.Location)
                                .Include(d => d.DashDetails)
                                .OrderByDescending(x => x.Date)
                                .ToListAsync();

            var dashModelData = mapper.Map<List<DailyDash>, List<DailyDashModelV2>>(dashData);
            foreach (var dash in dashModelData)
            {
                var dashTimeInHour = (dash.EndTime - dash.StartTime).TotalHours;
                dash.HourlyRate = dash.Amount / dashTimeInHour;
                dash.DeliveryCount = dash.DashDetails.Count;
            }

            return dashModelData;
        }

        public async Task SaveAsync(DailyDash dailyDash)
        {
            await _context.DailyDashes.AddAsync(dailyDash);
        }
    }
}
