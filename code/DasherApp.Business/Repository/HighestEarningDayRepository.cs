using AutoMapper;
using DasherApp.Business.Repository.Interface;
using DasherApp.Data;
using DasherApp.Model;
using DasherApp.Model.Helper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DasherApp.Business.Repository
{
    public class HighestEarningDayRepository : BaseRepository, IHighestEarningDayRepository
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public HighestEarningDayRepository(AppDbContext context, IMapper mapper) : base(context)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<OutputModel> GetHighestEarningDayAsync(DailyDashFilterParams dailyDashFilterParams)
        {
            var query = GetDailyDashesQuery(dailyDashFilterParams);
            var output  = await query.GroupBy(x => x.Date)
                .Select(g => new OutputModel
                {
                    Date = g.Key,
                    Value = g.Sum(x => x.Amount)
                })
                .OrderByDescending(x => x.Value)
                .FirstOrDefaultAsync();

            return output;
        }
    }
}
