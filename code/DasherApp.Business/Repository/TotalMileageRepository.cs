using AutoMapper;
using DasherApp.Business.Repository.Interface;
using DasherApp.Data;
using DasherApp.Model.Helper;
using Microsoft.EntityFrameworkCore;

namespace DasherApp.Business.Repository
{
    public class TotalMileageRepository : BaseRepository, ITotalMileageRepository
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;
        public TotalMileageRepository(AppDbContext appContext, IMapper mapper) : base(appContext)
        {
            context = appContext;
            this.mapper = mapper;
        }

        public async Task<double> GetTotalMileageAsync(DailyDashFilterParams dailyDashFilterParams)
        {
            try
            {
                var query = GetDailyDashesQuery(dailyDashFilterParams);
                var amount = await query.SumAsync(x => x.Mileage);
                return amount;
            }
            catch (Exception ex)
            {

            }

            return 0;
        }
    }
}
