using AutoMapper;
using DasherApp.API.Data.Entity;
using DasherApp.Models;

namespace DasherApp.API.Mapper
{
    public class DailyDashProfile : Profile
    {
        public DailyDashProfile()
        {
            CreateMap<DailyDash, DailyDashModel>().ReverseMap();
        }
    }
}
