
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
            //var dailyDashList = await context.DailyDash
            //                    .OrderByDescending(x => x.Date)
            //                    .Take(10)
            //                    .ToListAsync();

            var dailyDashList = await context.DailyDash
                               .OrderByDescending(x => x.Id)
                               .Take(10)
                               .ToListAsync();

            return mapper.Map<List<DailyDash>, List<DailyDashModel>>(dailyDashList);
        }

        public async Task<UpdateDailyDashModel> GetById(int id)
        {
            var dash = await context.DailyDash.SingleOrDefaultAsync(x => x.Id == id);
            return new UpdateDailyDashModel
            {
                Id = dash.Id,
                Amount = dash.Amount,
                StartTime = dash.StartTime.TimeOfDay,
                Date = dash.Date,
                EndTime = dash.EndTime.TimeOfDay,
                Location = dash.Location,
                Mileage = dash.Mileage
            };
        }

        public async Task<bool> Save(IEnumerable<DailyDashModel> dailyDashList)
        {
            foreach (DailyDashModel dailyDash in dailyDashList)
            {
                var dailyDashEntity = mapper.Map<DailyDashModel, DailyDash>(dailyDash);
                dailyDashEntity.Date = new DateTime(dailyDashEntity.Date.Year, dailyDashEntity.Date.Month,
                                                dailyDashEntity.Date.Day, 0, 0, 0);
                context.DailyDash.Add(dailyDashEntity);
            }

            return await context.SaveChangesAsync() > 0;
        }

        public async Task<double> TotalEarned()
        {
            var total = await context.DailyDash.SumAsync(x => x.Amount);
            return total;
        }

        public async Task<double> TotalMileage()
        {
            var total = await context.DailyDash.SumAsync(x => x.Mileage);
            return total;
        }

        public async Task<bool> Update(UpdateDailyDashModel updateDailyDashModel)
        {
            var dash = await context.DailyDash.FirstOrDefaultAsync(x => x.Id == updateDailyDashModel.Id);
            if (dash == null)
            {
                return false;
            }

            dash.Location = updateDailyDashModel.Location;
            dash.Date = updateDailyDashModel.Date;
            dash.StartTime = updateDailyDashModel.Date.Add(updateDailyDashModel.StartTime);
            dash.EndTime = updateDailyDashModel.Date.Add(updateDailyDashModel.EndTime);
            dash.Amount = updateDailyDashModel.Amount;
            dash.Mileage = updateDailyDashModel.Mileage;

            context.SaveChanges();

            return true;
        }
    }
}
