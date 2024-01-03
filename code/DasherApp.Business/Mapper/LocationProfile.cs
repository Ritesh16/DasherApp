using AutoMapper;
using DasherApp.Data.Entity;
using DasherApp.Model;

namespace DasherApp.Business.Mapper
{
    public class LocationProfile : Profile
    {
        public LocationProfile()
        {
            CreateMap<Location, LocationModel>().ReverseMap();
        }
    }
}
