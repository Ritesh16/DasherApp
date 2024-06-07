using AutoMapper;
using DasherApp.Business.Repository.Interface;
using DasherApp.Data;
using DasherApp.Model.Helper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DasherApp.Business.Repository
{
    public class TotalEarnedRepository : BaseRepository, ITotalEarnedRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper mapper;

        public TotalEarnedRepository(AppDbContext context, IMapper mapper) : base(context)
        {
            _context = context;
            this.mapper = mapper;
        }

        public async Task<double> GetTotalEarnedAsync(DailyDashFilterParams dailyDashFilterParams)
        {
            var amount = await GetDailyDashesQuery(dailyDashFilterParams).SumAsync(x => x.Amount);
            return amount;
        }
    }
}
