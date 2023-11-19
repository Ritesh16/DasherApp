using DasherApp.Data.Entity;

namespace DasherApp.Business.Repository.Interface
{
    public interface ILocationRepository
    {
        IEnumerable<Location> GetLocations();
        bool Save(Location location);
    }
}
