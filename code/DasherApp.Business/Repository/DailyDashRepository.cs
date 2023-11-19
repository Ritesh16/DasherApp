﻿using DasherApp.Business.Repository.Interface;
using DasherApp.Data;
using DasherApp.Data.Entity;

namespace DasherApp.Business.Repository
{
    public class DailyDashRepository : BaseRepository, IDailyDashRepository
    {
        private readonly AppDbContext _context;

        public DailyDashRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task SaveAsync(DailyDash dailyDash)
        {
            await _context.DailyDashes.AddAsync(dailyDash);
        }
    }
}