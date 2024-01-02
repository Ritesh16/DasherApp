using AutoMapper;
using DasherApp.Data.Entity;
using DasherApp.Model;

namespace DasherApp.Business.Mapper
{
    public class DailyDashProfile : Profile
    {
        public DailyDashProfile()
        {
            CreateMap<DailyDash, DailyDashModel>().ReverseMap();
        }
    }
}
