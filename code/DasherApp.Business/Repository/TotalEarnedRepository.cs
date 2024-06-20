using AutoMapper;
using DasherApp.Business.Repository.Interface;
using DasherApp.Data;
using DasherApp.Model.Helper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
            try
            {
                var query = GetDailyDashesQuery(dailyDashFilterParams);
                var amount = await query.SumAsync(x => x.Amount);
                return amount;
            }
            catch (Exception ex)
            {

            }

            return 0;
        }
    }
}
