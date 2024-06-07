using DasherApp.Data;
using DasherApp.Data.Entity;
using DasherApp.Model.Helper;
using System.Data.Entity;

namespace DasherApp.Business.Repository
{
    public class BaseRepository
    {
        private readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> SaveChanges()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public IQueryable<DailyDash> GetDailyDashesQuery(DailyDashFilterParams dailyDashFilterParams)
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

            return dashData;
        }
    }
}
