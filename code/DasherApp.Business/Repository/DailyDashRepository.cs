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

        public DailyDashRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DailyDash>> Get(FilterModel filterModel)
        {
            return await GetDailyDashQuery(filterModel).ToListAsync();
        }

        public async Task<IEnumerable<DailyDash>> GetAll()
        {
            var data = await _context.DailyDashes.Include("Location").ToListAsync();
            return data;
        }

        public async Task SaveAsync(DailyDash dailyDash)
        {
            await _context.DailyDashes.AddAsync(dailyDash);
        }
    }
}
