using AutoMapper;
using DasherApp.API.Data.Entity;
using DasherApp.API.Data.Repository.Interfaces;
using DasherApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DasherApp.API.Data.Repository
{
    public class DailyDashRepository : IDailyDashRepository
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public DailyDashRepository(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<DailyDashModel>> GetAll()
        {
            var dailyDashList = await context.DailyDash
                                .OrderByDescending(x => x.Date)
                                .Take(15)
                                .ToListAsync();

            return mapper.Map<List<DailyDash>, List<DailyDashModel>>(dailyDashList);
        }

        public async Task<bool> Save(IEnumerable<DailyDashModel> dailyDashList)
        {
            foreach (DailyDashModel dailyDash in dailyDashList)
            {
                var dailyDashEntity = mapper.Map<DailyDashModel, DailyDash>(dailyDash);
                context.DailyDash.Add(dailyDashEntity);
            }

            return await context.SaveChangesAsync() > 0;
        }
    }
}
