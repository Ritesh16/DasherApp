using AutoMapper;
using DasherApp.Data.Entity;
using DasherApp.Model;

namespace DasherApp.Business.Mapper
{
    public class DashDetailProfile : Profile
    {
        public DashDetailProfile()
        {
            CreateMap<DashDetail, DashDetailModel>().ReverseMap();
        }
    }
}
