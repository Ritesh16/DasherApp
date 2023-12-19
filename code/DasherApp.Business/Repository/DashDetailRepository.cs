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
            

            await _context.DashDetails.AddAsync(dashDetail);
        }
    }
}
