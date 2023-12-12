using DasherApp.Business.Repository.Interface;
using DasherApp.Data;
using DasherApp.Data.Entity;
using System.Data.Entity;

namespace DasherApp.Business.Repository
{
    public class DashDetailRepository : IDashDetailRepository
    {
        private readonly AppDbContext _context;
        public DashDetailRepository(AppDbContext context)
        {
            this._context = context;
        }

        public async Task Save(DashDetail dashDetail)
        {
            var dailyDash = _context.DailyDashes
                      .FirstOrDefault(x => x.StartTime <= dashDetail.OrderPickupTime && 
                                                x.EndTime >= dashDetail.OrderPickupTime);

            if(dailyDash != null)
            {
                dashDetail.DailyDashId = dailyDash.Id;
            }
            else
            {
                throw new Exception($"Problem saving dash detail. DailDash not found.");
            }

            await _context.DashDetails.AddAsync(dashDetail);
        }
    }
}
