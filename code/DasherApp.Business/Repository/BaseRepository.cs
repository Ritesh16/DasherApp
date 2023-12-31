using DasherApp.Data;
using DasherApp.Data.Entity;
using DasherApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DasherApp.Business.Repository
{
    public class BaseRepository
    {
        private readonly AppDbContext context;

        public BaseRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<bool> SaveChanges()
        {
            return await context.SaveChangesAsync() > 0;
        }
        public IQueryable<DailyDash> GetDailyDashQuery(FilterModel filterModel)
        {
            var query = context.DailyDashes.AsQueryable();

            if (filterModel.FromDate != null)
            {
                query = query.Where(x => x.StartTime >= filterModel.FromDate);
            }

            if (filterModel.ToDate != null)
            {
                query = query.Where(x => x.EndTime <= filterModel.ToDate);
            }

            if (!string.IsNullOrEmpty(filterModel.Location) && filterModel.Location != "all")
            {
                var q = query.Join(context.Locations,
                            l => l.LocationId,
                            d => d.Id,
                            (d, l) => new { DailyDash = d, Location = l }
                            ).Where(x => x.Location.Name == filterModel.Location)
                            .Select(x => x.DailyDash).AsQueryable();

                return q;
            }

            return query;
        }
    }
}
