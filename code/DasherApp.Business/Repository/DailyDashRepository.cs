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

        public async Task<IEnumerable<DailyDashModel>> GetAll()
        {
            var data = await _context.DailyDashes.Include("Location").ToListAsync();
            var output = mapper.Map<List<DailyDash>, List<DailyDashModel>>(data);
            return output;
        }

        public async Task SaveAsync(DailyDash dailyDash)
        {
            await _context.DailyDashes.AddAsync(dailyDash);
        }
    }
}
